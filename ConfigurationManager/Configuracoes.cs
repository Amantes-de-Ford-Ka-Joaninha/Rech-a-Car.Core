﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace ConfigurationManager.Combustivel
{
    public class Configuracoes
    {
        public Configuracoes(double valorEtanol, double valorDiesel, double valorGasolina, double valorCaucao)
        {
            ValorEtanol = valorEtanol;
            ValorDiesel = valorDiesel;
            ValorGasolina = valorGasolina;
            ValorCaucao = valorCaucao;
        }

        public double ValorEtanol { get; internal set; }
        public double ValorDiesel { get; internal set; }
        public double ValorGasolina { get; internal set; }
        public double ValorCaucao { get; internal set; }

        public static Configuracoes Configs
        {
            get
            {
                var path = Directory.GetCurrentDirectory() + "\\appsettings.json";
                JObject o1 = JObject.Parse(File.ReadAllText(path));

                var gasolina = o1["Gasolina"].ToObject<double>();
                var diesel = o1["Diesel"].ToObject<double>();
                var etanol = o1["Etanol"].ToObject<double>();
                var caucao = o1["Caucao"].ToObject<double>();

                return new Configuracoes(etanol, diesel, gasolina, caucao);
            }
        }

        public static bool SalvaValores(string strEtanol, string strDiesel, string strGasolina, string strCaucao)
        {
            if (Double.TryParse(strEtanol, out double etanol) &&
                Double.TryParse(strDiesel, out double diesel) &&
                Double.TryParse(strGasolina, out double gasolina) &&
                Double.TryParse(strCaucao, out double caucao) &&
                new double[] { etanol, diesel, gasolina, caucao }.All(x => x > 0))
            {
                SalvaConfiguracoes(new Configuracoes(etanol, diesel, gasolina, caucao));
                return true;
            }
            return false;
        }
        private static void SalvaConfiguracoes(Configuracoes config)
        {
            var path = Directory.GetCurrentDirectory() + "appsettings.json";
            JObject o1 = JObject.Parse(File.ReadAllText(path));
            o1["Gasolina"] = new JValue(config.ValorGasolina);
            o1["Diesel"] = new JValue(config.ValorDiesel);
            o1["Etanol"] = new JValue(config.ValorEtanol);

            o1["Caucao"] = new JValue(config.ValorCaucao);

            File.WriteAllText(path, JsonConvert.SerializeObject(o1));
        }
    }
}
