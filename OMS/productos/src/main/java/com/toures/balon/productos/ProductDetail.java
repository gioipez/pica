package com.toures.balon.productos;

import javax.persistence.*;
import java.util.Date;

@Entity
@Table(name="producto")
public class ProductDetail {
    @Id
    @GeneratedValue(strategy= GenerationType.AUTO)
    private Long id;

    private String codigo;

    private String nombre;

    private String descripcion;

    private String url_imagen;

    private String ciudad;

    private Date fecha_espectaculo;

    private Date fecha_llegada;

    private Date fecha_salida;

    private Float precio;

    public String getCodigo() {
        return codigo;
    }

    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public String getUrl_imagen() {
        return url_imagen;
    }

    public void setUrl_imagen(String url_imagen) {
        this.url_imagen = url_imagen;
    }

    public String getCiudad() {
        return ciudad;
    }

    public void setCiudad(String ciudad) {
        this.ciudad = ciudad;
    }

    public Date getFecha_espectaculo() {
        return fecha_espectaculo;
    }

    public void setFecha_espectaculo(Date fecha_espectaculo) {
        this.fecha_espectaculo = fecha_espectaculo;
    }

    public Date getFecha_llegada() {
        return fecha_llegada;
    }

    public void setFecha_llegada(Date fecha_llegada) {
        this.fecha_llegada = fecha_llegada;
    }

    public Date getFecha_salida() {
        return fecha_salida;
    }

    public void setFecha_salida(Date fecha_salida) {
        this.fecha_salida = fecha_salida;
    }

    public Float getPrecio() {
        return precio;
    }

    public void setPrecio(Float precio) {
        this.precio = precio;
    }
}
