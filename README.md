[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/XJVOx6rx)

Morales Soria Santiago

# ● ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación? 
Composicion: Pedidos con Clientes, porque si desaparece el pedido, entonces "desaparece" el cliente.

Agregacion: Cadete y Pedido, porque si "desaparece" el cadete y ese cadete tenia pedidos, entonces esos pedidos pueden o no ser reasignados a otros cadetes

# ● ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete? 
## Cadete
- AsignarPedido()
- EntregarPedido()


## Cadeteria
- 

# ● Teniendo en cuenta los principios de abstracción y ocultamiento, que campos, propiedades y métodos deberían ser públicos y cuáles privados. 
## Cadeteria
- Todo publico menos el listado de cadetes

## Cadete
- Todo publico menos la lista de pedidos, para acceder a ella se deberia crear un metodo para agregar, reasignar o eliminar pedidos

## Pedidos
- Todo publico, pero el cliente deberia ser de solo lectura

## Cliente
- Todo publico

# ● ¿Cómo diseñaría los constructores de cada una de las clases? 
```cs
    public Cadeteria(string nombre, string Telefono);
    public Cadete(int id, string nombre, string direccion, string telefono);
    public Pedido(int numero, string obs, Cliente cliente);
    public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)

    enum EstadoPedido{...}
```
## Consideraciones
- El telefono puede manejarse como entero largo o como string, pero eso depende del formato pues algunos escriben "381 224-0000", otros "3812240000", "3815 22 4944", "5493818559299", "+54 9 381 855 9299", ..., y al ser un string esto se omite totalmente
- Por defecto el estado de un pedido seria por ejemplo "CREADO"
- Estamos hablando del constructor, no seria practico agregar al inicio de la Cadeteria los cadetes, ya que eso se puede hacer luego con un metodo o accediendo directamente a la lista

# ● ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?

Una de esas alternativas seria que Cadeteria tuviera:
- Lo que sugiere el primer diagrama
- ListadoPedidos
- El metodo "EliminarCadete()" cuya funcionalidad seria eliminar un cadete y reasignar todos los pedidos
- AsignarPedido()

Cade pedido tendria:
- Lo propuesto
- Atributo CadeteAsignado
- CambiarCadete() que cambie su cadete asignado (encapsulamiento)

Aunque posee algunos inconvenientes y la estructura final parece muy burocratica