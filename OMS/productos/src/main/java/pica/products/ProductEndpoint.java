package pica.products;

import org.eclipse.microprofile.faulttolerance.Fallback;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpEntity;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestTemplate;

@Controller
@RequestMapping(path="/product")
public class ProductEndpoint {

    @Autowired
    private ProductRepository productRepository;

    @GetMapping
    @Fallback(fallbackMethod = "getQuickFactsFallback")
    public @ResponseBody
    ResponseEntity getProduct(
            @RequestParam(name = "page", required = false, defaultValue = "0") Integer page,
            @RequestParam(name = "codigo", required = false, defaultValue = "0") String codigo){
        if (!codigo.equals("0")){
            Product tmpProduct;
            try {
                tmpProduct = productRepository.findProudctByCode(codigo);
            } catch (Exception e) {
                return ResponseEntity.badRequest().body("Error during product request!\n");
            }

            return ResponseEntity.ok().body(tmpProduct);
        }
        Pageable pagesElement = PageRequest.of(page, 5);
        return ResponseEntity.ok().body(productRepository.findAll(pagesElement));
    }

    public @ResponseBody String getQuickFactsFallback(String loc) {
        return "Error while getting the service";
    }

    @PostMapping(value = "/createProduct")
    public ResponseEntity createProduct(@RequestBody Product theProduct){
        return ResponseEntity.ok().body(saveInDB(theProduct));
    }

    @PostMapping
    public ResponseEntity indexElastic(@RequestBody Product theProduct){
        if (saveInDB(theProduct)) {
            if (saveInElastic(theProduct)){
                return ResponseEntity.ok().body("Product save without error in Elastic and DB");
            }
            return ResponseEntity.badRequest().body("Error while saving in Elastic");
        } else {
            return ResponseEntity.badRequest().body("Error while saving in DB");
        }
    }

    private boolean saveInDB(Product toSaveProduct){
        try{
            productRepository.save(toSaveProduct);
        } catch (Exception e) {
            return false;
        }
        return true;
    }

    private boolean saveInElastic(Product theProduct){
        try{
            final String elasticUri = "http://201.226.152.89:9200/producto/deportes/" + theProduct.getCodigo();
            RestTemplate restTemplate = new RestTemplate();

            HttpEntity<Product> requestBody = new HttpEntity<>(theProduct);

            Product result = restTemplate.postForObject(elasticUri, requestBody, Product.class);
        }catch (Exception e){
            return false;
        }
        return true;
    }

    // #### Find out the way to update the product in DB
    @PutMapping(value = "/{id}")
    public ResponseEntity updateProduct(@RequestBody Product theProduct, @PathVariable Long id){
        Product foundProduct = productRepository.gioFindById(id);

        foundProduct = theProduct;

        return ResponseEntity.ok().body(saveInDB(theProduct));
    }

}
