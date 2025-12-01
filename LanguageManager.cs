using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpFastDesktop
{
    public static class LanguageManager
    {
        public static string IdiomaAtual = "pt"; // pt ou en

        // Dicionário de traduções
        public static Dictionary<string, (string pt, string en)> Textos =
            new Dictionary<string, (string pt, string en)>
        {
            { "login_usuario", ("Usuário", "Username") },
            { "login_senha", ("Senha", "Password") },
            { "login_entrar", ("Entrar", "Login") },

            { "chamados_titulo", ("CHAMADOS", "TICKETS") },
            { "btn_todos", ("TODOS OS CHAMADOS", "ALL TICKETS") },
            { "btn_novos", ("CHAMADOS NOVOS", "NEW TICKETS") },
            { "btn_pendentes", ("CHAMADOS PENDENTES", "PENDING TICKETS") },
            { "btn_relatorios", ("RELATÓRIOS DE CHAMADOS", "TICKET REPORTS") },
            { "btn_config", ("CONFIGURAÇÕES", "SETTINGS") },

            { "config_titulo", ("CONFIGURAÇÕES", "SETTINGS") },
            { "config_idioma", ("Idioma", "Language") },
            { "config_voltar", ("VOLTAR", "BACK") },
        };

        // Retorna o texto traduzido
        public static string T(string key)
        {
            if (!Textos.ContainsKey(key)) return key;

            return IdiomaAtual == "pt" ? Textos[key].pt : Textos[key].en;
        }
    }
}
