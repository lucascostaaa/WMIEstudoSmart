# Leitor de Dados SMART de Discos

Este programa é uma ferramenta de linha de comando que consulta e exibe informações SMART (*Self-Monitoring, Analysis, and Reporting Technology*) de discos rígidos e SSDs no sistema. Ele utiliza a interface WMI (*Windows Management Instrumentation*) para acessar os dados SMART através do namespace `MSStorageDriver_ATAPISmartData`.

## Funcionalidades

- Consulta dados SMART de todos os discos detectados no sistema.
- Decodifica e exibe atributos SMART selecionados, como taxa de erro de leitura, desempenho, horas de operação, temperatura do disco, entre outros.

## Pré-requisitos

- Windows 7 ou superior.
- .NET Framework 4.5 ou superior.

## Como Configurar

1. Certifique-se de que o .NET Framework 4.5 ou superior está instalado no seu sistema.
2. Clone este repositório ou baixe os arquivos fonte para o seu computador.

## Como Executar

Abra o Prompt de Comando ou PowerShell na pasta onde os arquivos fonte foram salvos e siga estes passos:

1. Compile o código utilizando o `estudoSmart.exe` (C# Compiler) que está incluído no .NET Framework. Por exemplo:

   ```bash
   Program.cs
   
## Possíveis Problemas

1. Acesso Negado: Certifique-se de que o programa seja executado com privilégios de administrador, pois a consulta de dados SMART pode requerer permissões elevadas.
2. Dados SMART não disponíveis: Alguns discos ou sistemas podem não suportar a leitura de dados SMART através de WMI, ou o suporte ao SMART pode estar desabilitado na BIOS/UEFI.

## Informações Coletadas (Desktop, não foi possivel coletar as informações de Notebook)
![image](https://github.com/lucascostaaa/WMIEstudoSmart/assets/56397638/9fc0eb5e-2e02-446f-9b66-0b2ef6318de7)
