<br>

<p align="center"><img src="./Imagens/Logo-Digital-Innovation-One.svg" width="156px" alt="Logo Dio.me"></p>

<h1 align="center">DIO - Trilha .NET - Explorando a linguagem C#</h1>
<h2 align="center">Desafio: Criando um Sistema de Hospedagem de Hotéis</h2>

<br>

> Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de explorando a linguagem C#, da trilha .NET da DIO.

<br>

## 📝: Alterações Realizadas

- **Métodos do desafio implementados.**
    - Cadastrar hóspede, suíte e reserva
    - Calcular valor diária
    - Obter quantidade de hóspedes
    - Uso de exception caso a quantidade de hóspedes cadastrados ultrapasse a capacidade da suíte.

- **Menu principal**
    - Submenu Suítes
    - Submenu Reservas

- **Suítes**
  - Cadastrar nova suíte
  - Remover suíte
  - Listar todas as suítes

- **Reservas**
  - Cadastrar nova reserva
    - Cadastrar hóspedes da reserva
  - Remover reserva
  - Listar todas as reservas

- **Validações**
    - Valida nomes de suítes repetidos.
    - Valida se a suíte existe antes de realizar a reserva.
    - Valida se há reserva existentes antes de remover uma suíte.
    - Valida a quantidade de hóspedes por reserva de suíte.
    - Valida campos em branco para hóspedes, suítes e reservas.

- Listagens tabuladas e indentadas para melhor visualização. 

- **Melhorias de qualidade de vida no geral**

<br>

## 💻: Contexto
Você foi contratado para construir um sistema de hospedagem, que será usado para realizar uma reserva em um hotel. Você precisará usar a classe Pessoa, que representa o hóspede, a classe Suíte, e a classe Reserva, que fará um relacionamento entre ambos.

O seu programa deverá cálcular corretamente os valores dos métodos da classe Reserva, que precisará trazer a quantidade de hóspedes e o valor da diária, concedendo um desconto de 10% para caso a reserva seja para um período maior que 10 dias.

<br>

## 📋: Regras e validações
- 1. Não deve ser possível realizar uma reserva de uma suíte com capacidade menor do que a quantidade de hóspedes. Exemplo: Se é uma suíte capaz de hospedar 2 pessoas, então ao passar 3 hóspedes deverá retornar uma exception.

- 2. O método ObterQuantidadeHospedes da classe Reserva deverá retornar a quantidade total de hóspedes, enquanto que o método CalcularValorDiaria deverá retornar o valor da diária (Dias reservados x valor da diária).

- 3. Caso seja feita uma reserva igual ou maior que 10 dias, deverá ser concedido um desconto de 10% no valor da diária.

<br>

<p align="center"><img src="./Imagens/diagrama_classe_hotel.png" alt="Diagrama de classe estacionamento"></p>

<br>

## 🔍: Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.

<br><hr><br>

## 🔗: Links e Referencias:

- **Sobre o Bootcamp**: https://www.dio.me/bootcamp/gft-start-7-net
- **DIO.me**: https://www.dio.me/