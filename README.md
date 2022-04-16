## Índice


# 1. Un poco de historia
Desde el interior del bosque esta empezando a resurgir el mal. Los exploradores han determinado que el origen se encuentra dentro de un castillo en lo más profundo del bosque. Se ha formado un pequeño grupo para intentar acabar con este mal.
Dentro de este grupo se encuentra la protagonista, una gerrera experimentada.
En el interior del bosque el grupo sufre una emboscada y todos los miembros del grupo mueren, salvo nuestra protagonista que acaba gravemente herida. Ella sola tendrá que poner fin a este mal.

# 2. Pantallas

## 2.1. Pantalla de Título
La pantalla inicial de la aventura. Aquí el jugador va a poder empezar una nueva partida. Si ha jugado préviamente tendrá disponible la opción de continuar su partida en el escenario donde lo había dejado. Finalmente podrá salir del juego, para esto se le pedirá que confirme su acción.

## 2.2. El Bosque
Este nivel es el tutorial de la aventura. Mediante una serie de retos sencillos se explica de forma visual e intuitiva al jugador las interacciones básicas que puede hacer durante la aventura. Las plataformas son sencillas y no presentan riesgo de muerte para el jugador.
## 2.3. Entrando en el Castillo
Empiezan a complicarse las cosas. Dentro del castillo hay más peligros y retos para el jugador. El número de enemigos es elevado y hay plataformas que pueden provocar la muerte del jugador.
## 2.4. La Torre
A llegado la hora de la verdad, en este escenario lucharemos con el goblin. Este actúa como jefe final de la aventura. Tiene más salud que los enemigos normales y alguna sorpresa más...

## 2.5. Pantalla de fin de Partida
En esta pantalla dependiendo del resultado de la partida se mostrará la victoria o la derrota del jugador y se le guiará hasta la pantalla principal.

# 3. Acciones del Jugador

## 3.1. Moverse
## 3.2. Atacar cuerpo a puerpo
Como su nombre indica es un ataque a corta distancia que puede realizar el jugador. Esta configurado por defecto con el botón izquierdo del ratón. En el momento de pulsarlo se mostrará la animación y se aplicarán sus efectos a los elementos cercanos. Hay un tiempo mínimo entre ataques para evitar que se abuse de esta acción.

## 3.3. Saltar
La habilidad básica de saltar esta limitada a que el personaje se encuentre en el suelo. No es posible saltar en el aire y tampoco es posible salar múltiples veces. Por defecto esta acción esta en la tecla Espacio.

## 3.4. Interactuar
Durante el transcurso de la aventura el jugador se irá encontrando cofres repartidos a lo largo de los niveles. Cuando el jugador esta lo suficientemente cerca de uno puede interactuar con el. Por defecto la tecla de interacción es la E.
Al hacerlo el cofre se abrirá y saldrá su contenido. En este caso son varias monedas de oro.

## 3.5. Recoger Objetos
En el juego hay ciertos objetos que el jugador puede recoger. Para hacer esta acción solo debe pasar por encima de ellos y su effecto se producirá.

## 3.6. Esquivar

# 4. Objetos
## 4.1. Rubíes
Esparcidos por el escenario se pueden encontrar estos rubíes. El jugador puede coleccionarlos. La idea original era tratar estos elementos como puntos de experiéncia para subir de nivel al jugador. Esta funcionalidad no se a implementado.

## 4.2. Cofres
Un cofre dorado y reluciente. El jugador puede interactuar con el para abrirlo y ver su contenido. En esta aventura soltará varias monedas de oro.
## 4.3. Monedas de Oro
Otro objeto colleccionable del juego. En un principio solo sirve para esto, coleccionar. Este objeto solo se puede obtener al interactuar con un cofre.

## 4.4. Cajas de Madera
Una caja de madera normal y corriente. El jugador puede atacar para romperla y ver su contenido. En nuestra aventura estas cajas siempre contienen una poción de salud para el jugador.

## 4.5. Pociones de Salud
Este objeto permite restaurar la salud del jugador en su totalidad. Solo es posible obtenerlo al romper las cajas de madera.

# 5. Enemigos

## 5.1. Esqueleto
El esqueleto es un enemigo que puede atacar al jugador pero no dispone de la capacidad de moverse. Su comportamiento es el siguiente:

## 5.2. Seta
La seta es un monstruo que no ataca al jugador directamente. Su comportamiento es el siguiente:
- Mira si el jugador esta dentro del rango de acción.
- Si esta dentro de este rango irá caminando hasta su posición
- Cuando este lo suficientemente cerca del jugador le intentará tocar para provocarle daño.
- Si el juagor golpea a la seta esta se quedará quieda un pequeño interválo de tiempo.
## 5.3. Monstruo volador

## 5.4. Goblin


# 6. Decisiones de diseño
## 6.1. Estilo de Juego
He decidido hacer un juego más del tipo Castlevania. Me a parecido un reto más interesante y me da un abanico de posibilidades más grande que el Super Mario en 2D.

### 6.2. Sistema de guardado
Como la aventura dispone de tres niveles he decidido implementar un sistema de guardado automático. Para hacerlo simplemente he creado una clase con la información de la partida que sea serializable. Esta clase contiene la información básica de la partida:
>- Salud actual del jugador.
>- Salud máxima del jugador.
>- Nivel actual.
>- Monedas recogidas.
>- Rubíes recogidos.
Esta información se guarda en un fichero codificado con el BinaryFormatter (para que los listillos no hagan trampas y intenten modificar este fichero).
Al final de cada nivel se actualiza el nivel actual y se sobreescribe el fichero.
En la pantalla principal si el jugador dispone de un fichero de guardado la opción de continuar estará disponible, si hace clic podrá seguir desde EL PRINCIPIO DEL NIVEL.
En el caso de que el jugador quiera empezar una nueva partida se eliminará el fichero de guardado.
Finalmente si el jugador completa la aventura este fichero también se borrará.
Esto me ha permitido no tener que poner el Game Manager como un objeto que no se destruya al cargar la escena. De esta manera no me tengo que preocupar del estado en el que esta. En el momento en el que se crea ya carga la configuración y ya esta.

### 6.3. UI de los coleccionables
Un dolor de cabeza. En mi etapa de diseño del juego quedaba muy bien que cuando el jugador coja colleccionables aparezca el contador con animación y desaparezca en unos segundos. En la práctica ha sido complicado y he tenido que investigar varias cosas.
En primer lugar si quiero el objecto con su animación tengo que utilizar un GameObject, estos elementos no se pueden poner directamente sobre el canvas.

### 6.4. Pantalla de pausa
Al estar ante un juego de plataformas me ha parecido interesante que tenga un sistema de pausa. He utilizado la tecla escape para realizar esta acción.
Además he querido dar al jugador la posibilad de terminar su sesión de juego añadiendo la opción de salir del nivel.
Aquí he tenido un problema, para la acción de salir del nivel he añadido la confirmación del jugador. Esto provocaba que dentro del menú de pausa si el jugador ha pulsado en el botón de salir y esta en el menú de confirmación se pusiera en marcha la partida y se quedaba el canvas de la confirmación de la salida. Para solucionar esto he añadido una variable para saber si estoy en la confirmación de salida. Si se da este caso al pulsar escape se sale de la confirmación y no de la pausa. Finalmente si se le vuelve a dar a escape el menú de pausa acabar y se reanuda la partida.
Para parar todos los objetos de la escena he puesto el timeScale a 0.
Finalmente como todo buen menú de pausa muestra el número de coleccionables que tiene el jugador.

### 6.5. Inteligencia artifial de los enemigos

### 6.6. Game Manager
He decidido hacer una Game Manger con el patrón de diseño Singleton. Esto me permite no tener que preocuparme por tener que importar en todos los lugares este elemento y me ahorra hacer métodos estáticos dentro.
Con el sistema de guardado he eliminado la opción de hacer que el Game Manager no se destruya. Lo he hecho para tener que evitar pensar en que estado esta entre escenas. Sobre todo por las transiciones entre niveles de juego y el menú principal.
Además con el Singleton el resto de componentes lo tienen más fácil para realizar llamadas de métodos.
He intentado simplificar al máximo el Game Manager para que haga las mínimas cosas:
>- Controlar si la partida se ha terminado.
>- Controlar si el jugador ha superado el nivel.
>- Controlar si el jugador desea terminar la partida.

### 6.7. Sistema de salud


### 6.8. Sistema de combate del jugador

### 6.9. Parallax

## 7. Recursos de terceros utilizados