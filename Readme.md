### ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
##### Entre las relaciones que existen entre las clases, vemos que los pedidos y el cliente tienen una relacion por composicion, debido a que cada cliente forma parte de un pedido (si el pedido no existe se borra el cliente); los pedidos y el cadete tienen una relacion por agregacion, debido a cada pedido puede ser reasignado a otro cadete; los cadetes y la cadeteria tienen una relacion de composicion, ya que si se elimina la cadeteria entonces el cadete tambien tendria que eliminarse

### ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
##### Metodos que deberian tener, Cadete tendria Añadir pedido para añadir el pedido a su lista de pedidos y otros para hacer visible los datos del cadete, en Cadeteria deberia tener metodos como para asignar pedidos a cadete, para cargar la info de cadete, para encontrar un cadete por un numero de id, etc.

### Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.
##### Con estos principios, los atributos deberian ser privados, siendo posible acceder a ellos a traves de metodos publicos.

### ¿Cómo diseñaría los constructores de cada una de las clases?

##### Cada constructor de cada clase se hará dependiendo de sus relaciones por composicion o agregacion. Por ejemplo, la clase cadeteria tendrá en su constructor la lista de cadetes con la que cuenta, por lo que si se elimina la cadeteria, tambien se eliminaran los cadetes. Otro ejemplo es la clase Pedidos, la cual tiene un cliente asociado, por lo que si se elimina el pedido también lo hará el cliente.
