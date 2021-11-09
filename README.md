# Digital
Prueba Tecnica para DigitalWare

En la carpeta Project5 se encuentra el proyecto de backend(NET CORE) y frontend(Angular).

En la carpeta Facturacion.Core se encuentra una parte de las capas de la arquitectura


En el archivo Punto1.sql se cuentra la parte de punto 1 que tiene que ver con base de datos, tanto estructura como algo de datos.

## Base de datos

Se creó una base de datos en SQL Server 15, con el nombre de **Facturacion**
 
Dentro de la base de datos se crearon 4 tablas:

- Cliente: En esta tabla encontrada los datos básicos del cliente
- Compra: Contiene los datos generales de la compra
- DetalleCompra: Contiene el detalle de los productos comprados
- Producto: Contiene los datos básicos de los productos

La tabla **Cliente** tiene los siguientes datos:
- Id: Esta es la llave primaria de la tabla, se creó una regla para que se generara de forma automática. Se usa un tipo de dato uniqueidentifier(Guid) para más seguridad en las claves primarias.
- Nombres: Nombres del cliente
- Apellidos: Apellidos del cliente
- Identificacion (Numero del documento de identidad, ya que esta en texto soporta puntos(.), comas(,) o Letras como es el caso de los pasaportes
- Celular: número de celular del cliente (esta en texto por lo cual soporta indicativos o caracteres especiales)
- Email: correo electrónico del cliente
- Edad: edad en numero del cliente (valor entero)
- FechaNacimiento: fecha de nacimiento (dd/mm/aaaa) del cliente

La tabla **Compra** tiene los siguientes datos:
- Id: Esta es la llave primaria de la tabla, se creó una regla para que se generara de forma automática. Se usa un tipo de dato uniqueidentifier(Guid) para más seguridad en las 
- IdCliente: es el id correspondiente del cliente que se encuentra en la tabla Cliente
- ValorTotal: contiene el valor total de la compra
- Fecha: fecha de la compra
- Usuario: Usuario que expidio o fue el asesora en la compra por parte del cliente

La tabla **DetalleCompra** tiene los siguientes datos:
- Id: Esta es la llave primaria de la tabla, se creó una regla para que se generara de forma automática. Se usa un tipo de dato uniqueidentifier(Guid) para más seguridad en las 
- IdCompra: es el id correspondiente de la compra que se encuentra en la tabla Compra
- IdProducto: es el id correspondiente del producto que se encuentra en la tabla Producto
- Cantidad: cantidad en unidades del producto comprado
- ValorProducto: contiene el valor total para ese producto

La tabla **Producto** tiene los siguientes datos:
- Id: Esta es la llave primaria de la tabla, se creó una regla para que se generara de forma automática. Se usa un tipo de dato uniqueidentifier(Guid) para más seguridad en las 
- Nombre: nombre con el cual es facil de buscar el producto tal como papa, carne, etc
- Sigla: es un codigo corto 
- Codigo: es un codigo con el que se desea identificar el producto, se puede utilizar un nombre corto
- Descripcion. es una descripcion general del producto
- Cantidad: es el stock actual del producto
- PrecioActual: es el precio actual del producto, a lo cual se puede vender
- IdProducto: es el id correspondiente del producto que se encuentra en la tabla Producto
- Cantidad: cantidad en unidades del producto comprado
- ValorProducto: contiene el valor total para ese producto

## Tecnologías Utilizadas
En este producto utilizo las siguientes tecnologías:

- NET CORE 5
- SQL Server 
- DevExpress
- Angular
- Entity Framework

Se utilizo en el proyecto una implementación básica de arquitectura limpia en la cual tenemos: Entidades, Repositorios, usados en capas diferentes.

El backend y el frontend se pusieron en un solo proyecto con el fin de ser mas practicos a la hora de subir en GitHub, en un escenario real es mejor dejar las capas separadas en servidores separados.

En el archivo Digital/Project5/appsettings.json y en la seccion **ConnectionString** encontrará la cadena de conexión la cual podrá modificar a su gusto.

Recuerde que este proyecto esta en NET CORE 5, por lo cual paquetes que tienen que ver con Entity Framework tienen que ir también con la misma versión.

## Implementación

Para poder correr el proyecto necesita Angular 6+ y NET CORE 5 como versiones mínimas.

El proyecto como tal del frontend esta en la carpeta **Digital/Project5/ClientApp/**

La parte de backend esta asi:

- WebApi: Los controladores estan en la carpeta Digital/Project5/Controllers/
- Contexto de datos: esta en el archivo Digital/Facturacion.Core/Data/FacturacionContext.cs
- Entidades: Las entidades para las 4 tablas que se crearon estan en la carpeta Digital/Facturacion.Core/Entities/
