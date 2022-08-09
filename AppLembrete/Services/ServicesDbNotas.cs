using System;
using System.Collections.Generic;
using System.Text;
using AppLembrete.Models;
using SQLite;

namespace AppLembrete.Services
{
    public class ServicesDbNotas
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }
        /// <summary>
        /// Construtor que define o banco e cria a tabela notas baseada no Models
        /// </summary>
        /// <param name="dbPath"></param>
        public ServicesDbNotas(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<ModelNotas>();
        }
        public void InserirNotas(ModelNotas nota)
        {
            try
            {
                if (!(String.IsNullOrEmpty(nota.Titulo.ToString()) || String.IsNullOrEmpty(nota.Nota.ToString())))
                {
                    int result = conn.Insert(nota);
                    if (result != 0)
                    {
                        StatusMessage = String.Format("{0} registro(s) adicionado(s)", result);
                    }
                    else
                    {
                        StatusMessage = String.Format("0 registro(s) adicionado(s)");
                    }

                }
                else
                {
                    StatusMessage = String.Format($"Não é possivel inserir esse registro. Informe o titulo " +
                    "e os dados da nota");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoverNota(int Id)
        {
            try
            {
                if (!String.IsNullOrEmpty(Id.ToString()))
                {
                    int result = conn.Table<ModelNotas>().Delete(r=>r.Id == Id);
                    StatusMessage = $"Remoção realizada com Sucesso";
                }
                else
                {
                    this.StatusMessage = String.Format("0 registro(s) removido(s): Informe o titulo " +
                        "e os dados da nota");
                }
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("0 registro(s) atualizado(s) {0}", e.Message));
            }
        }
        public List<ModelNotas> ListarNotas()
        {
            List<ModelNotas> lista = new List<ModelNotas>();
            try
            {
                lista = conn.Table<ModelNotas>().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);                    
            }
            return lista;
        }
        public void Atualizar(ModelNotas notas)
        {
            try
            {
                if (!String.IsNullOrEmpty(notas.Id.ToString()))
                {
                   int result = conn.Update(notas);
                    StatusMessage = $"Registro alterado com Sucesso";
                }
                else
                {
                    this.StatusMessage = String.Format("0 registro(s) atualizado(s): Informe o Id da nota");
                }
            }
            catch (Exception e)
            {
                throw new Exception( String.Format("0 registro(s) atualizado(s) {0}",e.Message));
            }
        }
        public List<ModelNotas> Localizar(string titulo) 
        {
            List<ModelNotas> lista = new List<ModelNotas>();
            try
            {
                // variavel recebe todo registro contido na tabela, quando o tituo dela for igual a da passada por parametro
                var resp = from reg in conn.Table<ModelNotas>()
                           where reg.Titulo.ToLower().Contains(titulo.ToLower())
                           select reg;
                lista = resp.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Erro: {0}", e.Message));
            }
            return lista;
        }
        public  ModelNotas GetNota(int id)
        {
            ModelNotas notas = new ModelNotas();
            try
            {
                notas = conn.Table<ModelNotas>().First(n => n.Id == id); // Conecta no banco e pega a nota com o id igual o do banco
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Erro: {0}", e.Message));
            }
            return notas;
        }
    }
}
