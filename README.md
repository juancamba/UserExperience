# UserExperience

La idea es hacer una aplicación e ir refactorizando y dejando traza en las ramas, haremos merges contra main, pero las ramas tendran nomenclatura numero-lo-que-hicimos.

La aplicacion es un api para guardar usuarios y workingexperiences de modo que un usuario puede tener 0-n working experiences.

## rama 1
Aqui la idea era centrarse en el modelo, las relaciones y como guardar los datos relacionados, de una forma chambona llamando al modelo desde el propio controlador.
De hecho aqui solo era probar que funciona la insercion de datos relacionados, ya que cuando llamo al metodo PostUser mete a fuego dos working experiences al usuario cuyo id viene por argumento del post

## rama 2-creating-repository
Aqui se refactoriza el controlador para que no haga llamadas directas al modelo, sino que se apoye en un repositorio, que es el que se encarga de hacer las llamadas al modelo.
Se crean los repositorios de usuario y working experience, y se refactoriza el controlador para que use estos repositorios.