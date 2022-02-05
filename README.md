# Observações:

Versão da Unity em que o setup foi feito: 2021.1.14f1

Foram feitas mudanças em:

-   Quais camadas (layers) colidem em ProjectSettings -> Physics2D
-   Adição de tags e camadas
-   Criação de alguns objetos e salvos como prefab (como classes que podem ser instanciadas):
    -   LightEmitter --> o objeto que emite a partícula
    -   LightReceiver --> onde a partícula deve chegar
    -   LightParticle --> a particula emitida
    -   LightReflector --> que irá refletir a particula

Há também scripts em Assets/Scripts que contém comentários para melhor entendimento
