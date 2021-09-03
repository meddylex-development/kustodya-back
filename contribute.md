# Como contribuir a Kustodya?

## Organizacion de los proyectos

- Pruebas y Codigo

- Arquitectura

### WebApi

* Servicios de Dominio
Corresponden a casos de uso del negocio. Funciones como la actualizacion y creacion de entidades, y tareas como envio de correos validaciones para la creacion de entidades, deberían llamarse desde aquí.

* Servicios de infraestructura
Corresponden a servicios externos como la persistencia, el envio de correos y servicios de mensajería. Estos servicios son implementaciones de las interfaces de Application Core.

* Servicios del WebApi
Si lo que buscas es generar un modelo de salida, este es el lugar para agregar un nuevo servicio. Estos servicios por lo general hacen uso de Automapper.

### Azure Functions

Estamos mejorando escalabilidad y costos de Kustodya usando funciones para las nuevas características.

- Convenciones
