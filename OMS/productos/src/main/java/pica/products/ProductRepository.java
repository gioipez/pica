package pica.products;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.PagingAndSortingRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.Date;

@Repository
public interface ProductRepository extends PagingAndSortingRepository<Product, Long> {

    @Query(value = "SELECT * FROM products p WHERE p.codigo = :productCode",
            nativeQuery = true)
    Product findProudctByCode(@Param("productCode") String codigo);

    @Query(value = "SELECT * FROM products p WHERE p.id = :id",
            nativeQuery = true)
    Product gioFindById(@Param("id") Long id);

}
