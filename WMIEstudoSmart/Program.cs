using System;
using System.Collections.Generic;
using System.Management;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSStorageDriver_ATAPISmartData");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                byte[] vendorSpecific = (byte[])queryObj["VendorSpecific"];

                // Exemplo de decodificação de alguns atributos SMART específicos
                Console.WriteLine("ID do Disco: " + queryObj["InstanceName"]);
                DecodeSmartData(vendorSpecific);
                Console.ReadLine();
            };
        }
        catch (ManagementException e)
        {
            Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
        }
    }

    static void DecodeSmartData(byte[] smartData)
    {
        // A estrutura exata dos dados pode variar. Este é um exemplo simplificado.
        for (int i = 2; i < smartData.Length; i += 12)
        {
            int attributeId = smartData[i];

            // Supondo que os dados brutos do valor estão nos índices 5 a 8
            long rawValue = BitConverter.ToInt32(smartData, i + 5);
            string attributeName = GetAttributeName(attributeId);

            if (!string.IsNullOrEmpty(attributeName))
            {
                Console.WriteLine($"{attributeName} (ID: {attributeId}): {rawValue}");
            }
        }
    }

    static string GetAttributeName(int id)
    {
        // Adicione aqui mais IDs de atributos conforme necessário
        var attributeNames = new Dictionary<int, string>()
        {
            { 1, "Taxa de Erro de Leitura" },
            { 2, "Desempenho Através do Disco" },
            { 3, "Tempo para Inicializar o Disco" },
            { 4, "Ciclos de Partida/Parada" },
            { 5, "Setores Reatribuídos" },
            { 7, "Taxa de Erros de Busca" },
            { 8, "Desempenho de Busca" },
            { 9, "Horas de Operação" },
            { 10, "Reinícios devido a Falhas de Rotação" },
            { 11, "Calibração de Reinício" },
            { 12, "Ciclos de Liga/Desliga" },
            { 13, "Erros de Leitura Suave" },
            { 183, "Eventos de Substituição de Reserva" },
            { 184, "Erros de Comunicação End-to-End" },
            { 187, "Erros Reportados Não Corrigidos" },
            { 188, "Execuções de Operação de Recuperação" },
            { 189, "Altas Temperaturas Operacionais" },
            { 190, "Temperatura do Disco" },
            { 191, "Erros de Recuperação de Disco" },
            { 192, "Ciclos de Ligação ao Encerramento de Emergência" },
            { 193, "Ciclos de Carregamento/Descarregamento" },
            { 194, "Temperatura do Disco" },
            { 195, "Erros de Recuperação de Hardware" },
            { 196, "Eventos de Realocação de Eventos" },
            { 197, "Setores em Espera" },
            { 198, "Setores Não Corrigíveis" },
            { 199, "Erros de CRC" },
            { 200, "Erros de Gravação Multi-Zona" },
            { 201, "Erros de Leitura Suave" },
            { 220, "Deslocamento de Disco" },
            { 222, "Tempo de Carregamento" },
            { 223, "Ciclos de Carga" },
            { 224, "Resistência de Carga" },
            { 225, "Ciclos de Carga Total" },
            { 226, "Tempo de Carregamento Total" },
            { 227, "Erros de Posicionamento Torácico" },
            { 228, "Quantidade de Ciclos de Liga/Desliga" },
            { 230, "Vida Útil do Disco" },
            { 231, "Condição do Disco" },
            { 232, "Vida Útil Restante do Disco" },
            { 233, "Ciclos de Programa/Apagamento" },
            { 234, "Contagem de Operações de Flash" },
            { 235, "Temperatura Mínima/Atual/Máxima do Disco" },
            { 240, "Tentativas de Rotação do Disco" },
            { 241, "Total de Bytes Escritos" },
            { 242, "Total de Bytes Lidos" },
            { 250, "Leitura de Erros de NAND" },
        };

        if (attributeNames.ContainsKey(id))
            return attributeNames[id];

        return null; // ou "Desconhecido" se preferir identificar IDs desconhecidos
    }
}
