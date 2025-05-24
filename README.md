
# 🛒 Sistema de Gestão de Pedidos

Sistema de pedidos desenvolvido com C# e ASP.NET Core aplicando os padrões de projeto **State** e **Template Method**. O sistema permite controle do ciclo de vida de um pedido e cálculo de frete conforme o tipo (aéreo ou terrestre), mantendo uma arquitetura limpa, extensível e de fácil manutenção.

---

## 📌 Sumário

- [📑 Descrição Geral](#-descrição-geral)
- [📐 Diagrama de Classes](#-diagrama-de-classes)
- [💾 Diagrama de Persistência](#-diagrama-de-persistência)
- [🧠 Padrões de Projeto Utilizados](#-padrões-de-projeto-utilizados)
- [📂 Estrutura de Pastas](#-estrutura-de-pastas)
- [🏗️ Responsabilidades das Camadas](#-responsabilidades-das-camadas)
- [🌐 Rotas da API](#-rotas-da-api)
- [🚀 Como Rodar o Projeto](#-como-rodar-o-projeto)
- [📌 Considerações Finais](#-considerações-finais)

---

## 📑 Descrição Geral

A aplicação permite que pedidos passem por diferentes estados (aguardando pagamento, pago, cancelado e enviado), controlados por classes que representam esses estados. O frete é calculado usando um algoritmo baseado no padrão Template Method, adaptando a lógica conforme o tipo de frete.

Além disso, o sistema:
- **Garante que pedidos cancelados não possam ser modificados**
- **Facilita a adição de novos métodos de frete e estados futuramente**
- **Encapsula regras de negócios e responsabilidades por camada**

---

## 📐 Diagrama de Classes

![Diagrama de Classe](https://github.com/user-attachments/assets/ed6bbbf7-2964-4480-9327-217e1b51be8c)


---

## 💾 Diagrama de Persistência

![Diagrama de Persistência](https://github.com/user-attachments/assets/c3864fc6-6359-42c4-a31a-6ea9840ac5fe)

### Entidades Principais

- **Pedido**
  - `idPedido`
  - `valorPedido`
  - `statusPedido` (enum)
- **Frete**
  - `idFrete`
  - `tipoFrete`
  - `taxaFrete`
- **Enums**
  - `StatusPedido`: AguardandoPagamento, Pago, Enviado, Cancelado
  - `TipoFrete`: Aéreo, Terrestre

---

## 🧠 Padrões de Projeto Utilizados

### 🔄 State Pattern

Permite que o objeto `Pedido` mude de comportamento dinamicamente conforme seu estado atual.

- Cada classe de estado implementa a interface `IPedidoState`.
- O `PedidoService` delega a execução de métodos como `Pagar`, `Cancelar` e `Enviar` ao estado atual.

### 🧮 Template Method Pattern

Usado no cálculo do frete:

- A classe abstrata `FreteTemplate` define a estrutura do algoritmo de cálculo.
- Subclasses (`FreteAereaTemplate` e `FreteTerrestreTemplate`) implementam os detalhes específicos.
- A taxa de frete é calculada com base no valor do pedido: 5% (terrestre) ou 10% (aéreo).

---

## 📂 Estrutura de Pastas

```
📁 Controllers
└─ PedidoController.cs
📁 Objects
 └─ 📁 DTOs
     └─ 📁 Entities
         ├─ PedidoDTO.cs
         └─ PedidoFreteRetornoDTO.cs
     └─ MappingProfile.cs
 └─ 📁 Models
     └─ Pedido.cs 
 └─ 📁 Enums
     ├─ StatusPedido.cs
     └─ TipoFrete.cs
📁 Services
 └─ 📁 Entities
     └─ PedidoService.cs
 └─ 📁 Interfaces
     └─ IPedidoService.cs
 └─ 📁 PedidoService
     └─ 📁 FretePedidoTemplate
         ├─ AFreteTemplate.cs
         ├─ FreteAereaTemplate.cs
         ├─ FreteTerrestreTemplate.cs
         └─ SetTemplateFretePedido.cs
     └─ 📁 PedidoState
         ├─ IPedidoState.cs
         ├─ AguardandoPagamentoState.cs
         ├─ PagoState.cs
         ├─ CanceladoState.cs
         ├─ EnviadoState.cs
         └─ SetStatePedido.cs
```

---

## 🏗️ Responsabilidades das Camadas

### 📂 Controllers
Responsáveis por receber as requisições HTTP, validar os dados básicos e encaminhá-los para os serviços. Não contêm lógica de negócios.

### 📂 Services
Contêm as regras de negócio da aplicação. Aqui são tratados os estados dos pedidos, o cálculo de frete e as conversões entre DTOs e Models.

- **State Pattern:** gerenciamento do ciclo de vida do pedido.
- **Template Method:** cálculo de frete adaptável.

### 📂 DTOs & Models
- **Models:** refletem a estrutura do banco de dados.
- **DTOs:** usados para entrada e saída de dados via API.

### 📂 Enums
Contêm os tipos fixos de dados como `StatusPedido` e `TipoFrete`, centralizando e organizando as constantes do sistema.

---

## 🌐 Rotas da API

| Verbo HTTP | Rota                          | Ação                                          |
|------------|-------------------------------|-----------------------------------------------|
| `GET`      | `/pedido`                     | Retorna todos os pedidos                      |
| `GET`      | `/pedido/{id}`                | Retorna um pedido específico                  |
| `POST`     | `/pedido`                     | Cria um novo pedido                           |
| `PATCH`    | `/pedido/{id}/pagar`          | Paga o pedido                                 |
| `PATCH`    | `/pedido/{id}/cancelar`       | Cancela o pedido                              |
| `PATCH`    | `/pedido/{id}/enviar`         | Envia o pedido                                |
| `GET`      | `/pedido/frete/{id}`          | Calcula e retorna o frete do pedido           |

---

## 🚀 Como Rodar o Projeto (Linux)

1. Clone o repositório:
   ```bash
   git clone https://github.com/GNSiqueira/20250425---Trabalho-de-Programa-o.git
   ```

2. Abra o projeto no Visual Studio.

3. Verifique a string de conexão com o banco de dados no arquivo `appsettings.json`.

4. Execute as migrations (caso necessário):
   ```bash
   dotnet ef database update
   ```

5. Execute o projeto com:
   ```bash
   dotnet run
   ```

---

## 📌 Considerações Finais

Este sistema foi construído com foco na clareza arquitetural e aplicação prática de padrões de projeto. Pode ser facilmente expandido com novos tipos de frete, estados de pedido e integrações externas.

Além disso, cada camada foi definida com responsabilidade única, facilitando a manutenção e testes unitários.
