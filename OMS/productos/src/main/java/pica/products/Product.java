package pica.products;

import javax.persistence.*;
import java.util.Date;

@Entity
@Table(name="products")
public class Product {
    @Id
    @GeneratedValue(strategy= GenerationType.AUTO)
    private Long id;

    // #### Colocar indices a esta caga
//    @Column(unique = true, nullable = false, updatable=true)
    private String codigo;

    private String nombre;

    private String descripcion;

    private String url_imagen;

    private String ciudad;

    private Date fecha_espectaculo;

    private Date fecha_llegada;

    private Date fecha_salida;

    private Date fecha_inicio_campana;

    private Date fecha_fin_campana;

    private boolean is_campain = false;

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

    public Date getFecha_inicio_campana() {
        return fecha_inicio_campana;
    }

    public void setFecha_inicio_campana(Date fecha_inicio_campana) {
        this.fecha_inicio_campana = fecha_inicio_campana;
    }

    public Date getFecha_fin_campana() {
        return fecha_fin_campana;
    }

    public void setFecha_fin_campana(Date fecha_fin_campana) {
        this.fecha_fin_campana = fecha_fin_campana;
    }

    public boolean isIs_campain() {
        return is_campain;
    }

    public void setIs_campain(boolean is_campain) {
        this.is_campain = is_campain;
    }
}
