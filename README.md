# UserExperience

Está basado en https://github.com/ElectNewt/curso-entity-framework/blob/main/02-CodeFirst/src/CursoEFCore.Codefirst/CursoEFCore.Codefirst.API/Program.cs

La idea es hacer una aplicación e ir refactorizando y dejando traza en las ramas, haremos merges contra main, pero las ramas tendran nomenclatura numero-lo-que-hicimos.

La aplicacion es un api para guardar usuarios y workingexperiences de modo que un usuario puede tener 0-n working experiences.

## rama 1
Aqui la idea era centrarse en el modelo, las relaciones y como guardar los datos relacionados, de una forma chambona llamando al modelo desde el propio controlador.
De hecho aqui solo era probar que funciona la insercion de datos relacionados, ya que cuando llamo al metodo PostUser mete a fuego dos working experiences al usuario cuyo id viene por argumento del post

## rama 2-creating-repository
Aqui se refactoriza el controlador para que no haga llamadas directas al modelo, sino que se apoye en un repositorio, que es el que se encarga de hacer las llamadas al modelo.
Se crean los repositorios de usuario y working experience, y se refactoriza el controlador para que use estos repositorios.


## rama 3-creating-unit-of-work
Creamos el unit of work, que es el que se encarga de hacer las transacciones, y el servicio InsertUserService, que es el que se encarga de hacer las llamadas a los repositorios.
Por así decirlo encapsula la transacción

Antes de continuar tienes que tener en cuenta una cosa, hasta que no insertas el primer valor en la base de datos (User en nuestro caso), 
no tienes acceso al Id para hacer la referencia (en WorkingExperience), por lo que lo más común que se suele hacer es, crear una propiedad virtual 
en tu entidad que se llama igual que la tabla donde vas a insertar, por ejemplo, en este ejemplo, WorkingExperiences tiene el campo userId, 
lo que hacemos es crear un virtual User, que hace referencia a la entidad de la tabla.
Esto es una práctica común y el los diferentes ORM saben detectar que el id de User hace referencia a tu UserId.


Pero pueden ocurrir referencias circulares. Para evitar esto, debes incluir configuración para el Serializer: 
```csharp
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
```
