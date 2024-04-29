namespace libDataValida
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 para teste automatico\n2 para teste manual");
            int teste = int.Parse(Console.ReadLine());

            if(teste == 1)
            {
                TesteAutomatico();
                Console.WriteLine("Aperte qualquer tecla para sair.");
                string valor = Console.ReadLine();
            }
            else if(teste == 2)
            {
                TesteManual();
            }
            else
            {
                Console.WriteLine("Valor inválido!");
            }
        }

        static void TesteAutomatico()
        {
            TestarCasoAutomatico("ESPERADO - válido (31 dias):", 31, 1, 2000);
            TestarCasoAutomatico("ESPERADO - válido (Fevereiro em ano bissexto):", 29, 2, 2020);
            TestarCasoAutomatico("ESPERADO - inválido (Fevereiro em ano não bissexto):", 29, 2, 2021);
            TestarCasoAutomatico("ESPERADO - inválido (dia fora do limite do mês):", 31, 4, 2000);
            TestarCasoAutomatico("ESPERADO - inválido (mês inválido):", 15, 13, 2000);
            TestarCasoAutomatico("ESPERADO - válido (último dia do mês):", 30, 6, 2000);
            TestarCasoAutomatico("ESPERADO - inválido (dia negativo):", -5, 8, 2022);
        }

        static void TestarCasoAutomatico(string txt, int dia, int mes, int ano)
        {
            Console.WriteLine(txt);
            Console.WriteLine("Dia: " + dia);
            Console.WriteLine("Mês: " + mes);
            Console.WriteLine("Ano: " + ano);

            if (IsDataValido(ano, mes, dia))
            {
                Console.WriteLine("Data válida. Parabéns!\n");
            }
            else
            {
                Console.WriteLine("Data inválida. :(\n");
            }

        }

        static void TesteManual()
        {
            int dia, mes, ano;

            while (true)
            {
                dia = InsereInt("Entre com o dia:");
                if (dia == 0)
                {
                    break;
                }

                mes = InsereInt("Entre com o mês:");
                ano = InsereInt("Entre com o ano:");

                if (IsDataValido(ano, mes, dia))
                {
                    Console.WriteLine("Data válida. Parabéns!\n");
                }
                else
                {
                    Console.WriteLine("Data inválida. :(\n");
                }
            }
        }



        static int InsereInt(string txt)
        {
            int valor;

            Console.WriteLine(txt);
            valor = int.Parse(Console.ReadLine());

            return valor;
        }

        static bool IsAnoValido(int ano)
        {
            if (ano >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static bool IsMesValido(int mes)
        {
            if (mes >= 1 && mes <= 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsDataValido(int ano, int mes, int dia)
        {
            if (IsAnoValido(ano) && IsMesValido(mes))
            {
                // Meses que tem 31 dias
                if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    if (dia >= 1 && dia <= 31)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // Meses que tem 30 dias
                else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
                {
                    if (dia >= 1 && dia <= 30)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // Mes de fevereiro
                else
                {
                    if ((!IsBissexto(ano) && dia <= 28) || IsBissexto(ano) && dia <= 29)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        static bool IsBissexto(int ano)
        {
            bool bissexto = false;
            if (ano % 400 == 0)
            {
                bissexto = true;
            }
            else if (ano % 4 == 0 && ano % 100 != 0)
            {
                bissexto = true;
            }
            return bissexto;
        }



    }
}

/* 
Caso válido (31 dias):
Dia: 31
Mês: 1 (Janeiro)
Ano: Qualquer ano
Esperado: Válido, pois Janeiro tem 31 dias

Caso válido (Fevereiro em ano bissexto):
Dia: 29
Mês: 2 (Fevereiro)
Ano: 2020 (ano bissexto)
Esperado: Válido, pois Fevereiro de 2020 tem 29 dias

Caso válido (Fevereiro em ano não bissexto):
Dia: 29
Mês: 2 (Fevereiro)
Ano: 2021 (ano não bissexto)
Esperado: Inválido, pois Fevereiro de 2021 tem apenas 28 dias

Caso inválido (dia fora do limite do mês):
Dia: 31
Mês: 4 (Abril)
Ano: Qualquer ano
Esperado: Inválido, pois Abril tem apenas 30 dias

Caso inválido (mês inválido):
Dia: 15
Mês: 13
Ano: Qualquer ano
Esperado: Inválido, pois não existe o mês 13

Caso válido (último dia do mês):
Dia: 30
Mês: 6 (Junho)
Ano: Qualquer ano
Esperado: Válido, pois Junho tem 30 dias

Caso inválido (dia negativo):
Dia: -5
Mês: 8 (Agosto)
Ano: 2022
Esperado: Inválido, pois o dia não pode ser negativo
 */
