# PEC2_Platform_Game

En esta PEC 2 se ha adaptado el primer nivel de Super Mario Bross. El personaje principal es un fantasma llamado Reji, su objetivo principal es conseguir llegar a un portal que le lleve de vuelta a su mundo natal. Su antagonista, un champiñon malvado, ara todo lo posible para impedir que Reji sea capaz de conseguir su meta.

## Index

- [Cómo jugar](https://gitlab.com/Tomas-Gayo/pec2_platform_game#c%C3%B3mo-jugar)
- [Escenas](https://gitlab.com/Tomas-Gayo/pec2_platform_game#escenas)
- [Demo](https://gitlab.com/Tomas-Gayo/pec2_platform_game#demo)
- [Estructura de carpetas](https://gitlab.com/Tomas-Gayo/pec2_platform_game#estructura-de-carpetas)
- [Animaciones](https://gitlab.com/Tomas-Gayo/pec2_platform_game#animaciones)
- [Música y Sonidos](https://gitlab.com/Tomas-Gayo/pec2_platform_game#m%C3%BAsica-y-sonidos)
- [Dificultades y aspectos a mejorar](https://gitlab.com/Tomas-Gayo/pec2_platform_game#dificultades-y-aspectos-a-mejorar)
- [Librerías](https://gitlab.com/Tomas-Gayo/pec2_platform_game/-/blob/main/README.md#librer%C3%ADas)
- [Atribuciones](https://gitlab.com/Tomas-Gayo/pec2_platform_game#atribuciones)

## Cómo jugar

- **Movimiento**: El protagonista tendrá la posibilidad de moverse horizontalmente con las teclas "A" (izquierda) y "D" (derecha). También, es capaz de saltar con la barra de "espacio". Teniendo esto en cuento seremos capaces de movernos por todo el escenario. 
Por otro lado, tenemos al enemigo champiñon. Este solo tiene movimiento horizontal. 

- **Ataque y Daño**: Se puede golpear al champiñon en la cabeza para matarlo. A su vez, el enemigo puede hacer daño al jugador simplemente tocandolo con cualquier parte del cuerpo excepto la cabeza. 

- **Vida**: Tanto Reji como el enemigo tienen una sola vida, no obstante, el jugador puede potenciarse con una vida más consiguendo un orbe especial, aunque el máximo es de dos vidas. 

- **Bloques**: Hay tres tipos de bloques repartidos por todo el escenario que se pueden golpear por debajo para activarlos:
    - Bloque misterioso: Estos bloques se golpean una única vez y siempre activarán un item, o un potenciador o una moneda. 
    - Bloque misterioso usado: Este es el bloque misterioso una vez se ha activado. No realiza ninguna acción.
    - Bloques ladrillo: Los bloques ladrillo son como los misteriosos pero no siempre activan un item. Además, si el jugador esta potenciado, entonces, podrá romper este bloque. 

<img src="/images/Blocks.PNG" alt="Tipos de bloques" width="250"/>

## Escenas

El juego consite en dos escenas: Menu incial y juego. Las pantallas de derrota y victoria estan embebidos en el canvas de la pantalla de juego.

- **Menu inicial**:

<img src="/images/MenuScreen.PNG" alt="Pantalla inicial" width="500"/>

Esta es la primera escena al inciar el juego. Dos botones centrales son los que marcan las acciones disponibles, empezar "New game" y "Exit game". Además, para ambientar al usuario, la escena se ha decorado con elementos utilizados en el juego como tiles o prefabs.

- **Pantalla de juego**:

<img src="/images/GameScreen.PNG" alt="Pantalla de juego" width="500"/>

Una vez seleccionado "Nuevo juego" en el menu principal, cambiamos de escena y llegamos a la pantalla de juego. Como se puede observar la escena consiste en una interfaz muy sencilla en la parte superior que contiene: la puntación del jugador, las monedas conseguidas y el tiempo restante; y el nivel de juego. 
También, se han incluido las pantallas de Game Over, para la derrota, y The End, para señalar que se ha llegado al final del juego. 

<img src="/images/GameOver.PNG" alt="Game Over" width="500"/>

<img src="/images/TheEnd.PNG" alt="The End" width="500"/>


## Demo

El juego se ha publicado en itch.io, [prueba el juego en su versión Web](https://toyoerin.itch.io/platform-game).

También podéis ver la [demostración del juego en video](https://youtu.be/OLrNxk-ojtY) en Youtube para su versión de PC. 

## Estructura de carpetas

<img src="/images/UnityFolder.PNG" alt="Estructura de carpetas"/>

Con la intención de mantener el máximo de orden posible el proyecto se ha dividido en diversas carpetas. Estas son: 
- "**Animations**": todas las animaciones y sus controladores se guardan aquí. 
- "**Asset Store**": se ha utilizado un asset adicional llamado "TextMesh Pro". Cualquier otro asset se podría poner en esta carpeta.
- "**Brushes**": los prefabs como los bloques o monedas no se colocan aleatoriamente por el escenrio. Para poder cuadrarlos con el grid se tienen que crear los brushes que se guardarán en este carpeta.
- "**Materials**": en esta carpeta se incluyen los materiales que se usaran en las físicas. En este caso solo hay el material hielo que se ha utilizado para que los diferentes personajes no se queden encasillados al interactuar con otras físicas. 
- "**Palettes**": estas son las paletas que se utilizan en el tilemap.
- "**Prefabs**": aquí se han guardado muchos elementos reutilizables, por ejemplo, un prefab para el enemigo, para los diferentes items, como monedas o _power-up_, decorados, los botones de la UI, etc. 
- "**Resources**": desde resources podemos acceder a todos los sonidos 
- "**Scenes**": las dos escenas del juego se pueden encontran aquí.
- "**Scripts**": posiblemente la carpeta más compleja de estructurar puesto que hay muchos _scripts_. En la imagen se puede observar que se han añadido diversas sub-carpetas para mantener un orden. 
- "**Sprites**": todos los sprites o imagenes se guardan aquí. Se ha intentado optimizar al máximo el espacio a partir de _sprite sheets_, por ejemplo, todos los sprites del personaje o el enemigo se incluyen en una sola hoja. 
- "**Tiles**": en esta carpeta estan los tiles individuales que se utilizan en el tilemap, cada tile se asigna a una paleta para poder utilizarla en el grid de la escena. 

## Animaciones

- **Jugador**:

<img src="/images/PlayerAnimator.PNG" alt="Animator del jugador"/>

El jugador tiene diferentes animaciones como se puede observar en la imagen de arriba. Su flujo comienza en el estado Idle, que corresponde al momento donde no recibe ninguna entrada del usuario. En el momento que recibe la señal enviada por las teclas de movimiento horizontal, entonces, se activa la animación "Walk". También, se puede recibir la entrada con la tecla salto, en consecuencia, se activará la animación "Jump". Esta animación realmente son varías animaciones (ver la imagen siguiente): despegue, cuando empieza deja de tocar el suelo; salto hacia arriba, cuando tiene velocidad positiva; salto hacia abajo, cuando tiene velocidad negativa; y aterrizaje,  cuando toca el suelo. El conjunto da como resultado una animación de salto. Po último, tenemos la animación de muerte que se activa cuando el jugador se queda sin vida.

<img src="/images/PlayerAnimator_Jump.PNG" alt="Animator del jugador en el salto"/>

- **Enemigo**:

<img src="/images/EnemyAnimator.PNG" alt="Animator del enemigo"/>

El enemigo a diferencia del jugador tiene tan solo dos animaciones, estas son, "Walk" y "Dead". Es decir, el enemigo siempre esta caminando excepto cuando reciba daño del jugador, en ese momento se activará la animación de muerte. 

- **Otras animaciones**:

Hay diversas animaciones en los diferentes elementos del juego. Las más detacadas son las de los items que tienen animaciones "Idle" y "Collect". También, podemos encontrar decoraciones animadas, como el conejo y la antorcha, aunque tan solo decorados. Por último, se ha experimentado con los _tiles_ animados, en este caso, se ha introducido la cascada con dos tiles animados para dar el efecto del agua al caer. 

## Música y Sonidos

Se han añadido multiples sonidos en los elementos del juego como en los bloques al ser golpeados o los items al ser recogidos. De la misma manera, el enemigo tiene un sonido particular al morir. Además, al finalizar el nivel sonará una especie de alarma que nos indicará la victoria. 
Para ambientar la partida se ha añadido una música de fondo con un aire misterioso y tranquilo, esta se reproduce en _loop_ tanto en el menu incial como en la pantalla de juego. 

## Dificultades y aspectos a mejorar 

Lo más complicado para esta PEC ha sido el tema de las colisiones y entender como funcionan los colliders. Aún habiendo acabado esta PEC, todavía quedan colisiones por pulir. Por mencionar alguna, el jugador se queda "volando" cuando colisiona con un potenciador mientras esta en movimiento durante un breve periodo de tiempo. Otro fallo de colisiones ocurre cuando el jugador esta potenciado y choca con el enemigo, en ese momento, se puede arrastrar al enemigo sin recibir daño. 
También, se puede hacer mención al tiempo requerido para encontrar el sonido y _sprites_ adecuados. Esto ha hecho que el jugador no tenga sonidos en las animaciones puesto que no se ha conseguido encontrar unos sonidos que casen correctamente con los distintos sonidos del juego. Para mejorar esto, sería más interesante buscar los sonidos desde un principio, ya que, para esta PEC se ha esperado al final y el tiempo en esa etapa de desarrollo es escaso. 

## Librerías
- **Text Mesh Pro**: Este asset se ha utilizado para mejorar los estilos de los textos en la UI. Funciona igual que los textos normales pero tiene más opciones de personalización.

- **Cinemachine**: este paquete se ha utilizado para configurar la camara para que pueda seguir al personaje. Con ello, se crea una cámara virtual al que se le asignará al jugador como elemento a seguir. Después de eso, se puden conseguir diferentes efectos con su multiples ajustes. 

- **2D Extras**: 2D extra permite hacer uso de los tiles y brushes que facilatarán la creación de niveles. 

## Atribuciones

- **Personajes, animaciones y escenario**: [Usuario o_lobster](https://o-lobster.itch.io/platformmetroidvania-pixel-art-asset-pack)

- **Bloques**: [Usuario Rotting Pixels](https://rottingpixels.itch.io/nature-platformer-tileset) 

- **Sonidos UI**: [Usuario Kenney](https://opengameart.org/users/kenney)

- **Música**: [Usuario adn_adn](https://opengameart.org/users/adnadn)

- **Sonido muerte chmpiñon**: [Usuario Bart](https://opengameart.org/users/bart)

- **Sonido rebote bloques**: [Usuario Lamoot](https://opengameart.org/users/lamoot) 

- **Sonidos de colección de items**: [Usuario HaelDB](https://opengameart.org/users/haeldb)

- **Sonido de cascada**: [Usuario Kurt](https://opengameart.org/users/kurt)

- **Sonido de victoria**: [Usuario Remaxim](https://opengameart.org/users/remaxim)







