# UserExperience

La idea es hacer una aplicación e ir refactorizando y dejando traza en las ramas, haremos merges contra main, pero las ramas tendran nomenclatura numero-lo-que-hicimos.

La aplicacion es un api para guardar usuarios y workingexperiences de modo que un usuario puede tener 0-n working experiences.

## rama 1
Aqui la idea era centrarse en el modelo, las relaciones y como guardar los datos relacionados, de una forma chambona llamando al modelo desde el propio controlador.
De hecho aqui solo era probar que funciona la insercion de datos relacionados, ya que cuando llamo al metodo PostUser mete a fuego dos working experiences al usuario cuyo id viene por argumento del post