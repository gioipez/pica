package com.toures.balon.productos;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

@Controller
@RequestMapping(path="/producto")
public class MainController {
    @Autowired
    private ProductDetailRepository productDetailRepository;


    @GetMapping
    public @ResponseBody
    ResponseEntity getProduct(
            @RequestParam(name = "page", required = false, defaultValue = "0") Integer page,
            @RequestParam(name = "codigo", required = false, defaultValue = "0") String codigo){
        if (!codigo.equals("0")){
            return ResponseEntity.ok().body(productDetailRepository.findProudctByCode(codigo));
        }
        Pageable pagesElement = PageRequest.of(page, 5);
        return ResponseEntity.ok().body(productDetailRepository.findAll(pagesElement));
    }

    @PostMapping
    public @ResponseBody ProductDetail addNewProduct(@RequestBody ProductDetail productFromBody){
        ProductDetail nP = new ProductDetail();
        nP.setCodigo(productFromBody.getCodigo());
        nP.setNombre(productFromBody.getNombre());
        nP.setDescripcion(productFromBody.getDescripcion());
        nP.setUrl_imagen(productFromBody.getUrl_imagen());
        nP.setCiudad(productFromBody.getCiudad());
        nP.setPrecio(productFromBody.getPrecio());
        return productDetailRepository.save(nP);
    }

}
