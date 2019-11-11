package com.toures.balon.productos;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.PagingAndSortingRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ProductDetailRepository extends PagingAndSortingRepository<ProductDetail, Long> {

    @Query(value = "SELECT * FROM producto p WHERE p.codigo = :productCode",
            nativeQuery = true)
    ProductDetail findProudctByCode(@Param("productCode") String codigo);

}
