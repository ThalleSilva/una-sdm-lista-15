Entrega de atividades referente a lista una-sdm-lista-15

 Pergunta: Explique como essa latência de 3 segundos impactaria uma frota de 10.000 veículos tentando reportar falhas simultaneamente. Qual estratégia de sistemas distribuídos
(ex: Mensageria/RabbitMQ ou Cache/Redis) você usaria para mitigar isso?

Resposta: Uma latência de 3 segundos com 10.000 veículos simultâneos gera sobrecarga, filas e risco de falhas na API. Para resolver, usa-se RabbitMQ para processar as requisições de forma assíncrona, evitando congestionamento.
