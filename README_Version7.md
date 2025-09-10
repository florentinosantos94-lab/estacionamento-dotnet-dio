# Sistema de Celulares - Desafio DIO .NET

Este projeto é um desafio prático do módulo "Orientação a Objetos" da trilha .NET da DIO.

## Contexto

Modelo de sistema de celulares usando abstração e herança, com classes para diferentes marcas e modelos.

### Funcionalidades

- Classe abstrata `Smartphone` como modelo base
- Classes filhas `Nokia` e `Iphone` com comportamentos distintos
- Método `InstalarAplicativo` sobrescrito nas classes filhas

### Regras e validações

- `Smartphone` não pode ser instanciada diretamente
- `Nokia` e `Iphone` devem herdar de `Smartphone`
- O método `InstalarAplicativo` é sobrescrito em cada modelo

## Como executar

1. Instale o .NET SDK ([Download](https://dotnet.microsoft.com/download))
2. Clone este repositório:
   ```bash
   git clone https://github.com/florentinosantos94-lab/sistema-celular-dotnet-dio.git
   cd sistema-celular-dotnet-dio
   ```
3. Compile e execute:
   ```bash
   dotnet run
   ```

## Estrutura de Pastas

- `Models/Smartphone.cs`
- `Models/Nokia.cs`
- `Models/Iphone.cs`
- `Program.cs` (ponto de entrada)

## Autor

[Florentino Santos](https://github.com/florentinosantos94-lab)