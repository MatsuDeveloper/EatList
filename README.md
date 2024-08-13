# EatList

**EatList** é um aplicativo de terminal para gerenciar listas de pedidos. Ele permite adicionar e remover itens, definir mensagens de saudação e imprimir a lista formatada com as quantidades apropriadas. disponível para Windows e Linux! 🪟🐧

## Docs'

- **add (item [quantidade])**: Adiciona um novo item à lista com a quantidade especificada. Se a quantidade não for fornecida, o padrão é 1.
  - Exemplo: `add "Pão" 3`

- **rm (item [quantidade])**: Remove um item da lista. Se a quantidade não for fornecida, o padrão é 1.
  - Exemplo: `rm "Pão" 2`

- **grt (mensagem)**: Define a mensagem de saudação. Use "bom dia", "boa tarde" ou "boa noite".
  - Exemplo: `grt "boa tarde"`

- **print**: Imprime a lista de pedidos com a mensagem de saudação e as quantidades formatadas.
  - Exemplo: `print`

## Exemplo de Uso

```bash
./EatList add "Pão" 3
./EatList add "Leite" 1
./EatList rm "Pão"
./EatList grt "boa tarde"
./EatList print
