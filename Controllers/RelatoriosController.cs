using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_car_ASPNETCORE.Models;
using System.Net.Mail;

namespace net_car_ASPNETCORE.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly net_car_ASPNETCOREContext _context;

        public RelatoriosController(net_car_ASPNETCOREContext context)
        {
            _context = context;
        }

        // GET: Relatorios/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: Relatorios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tipo_relatorio,email")] Relatorio relatorio)
        {
            try
            {
                var path = "";

                switch (relatorio.tipo_relatorio)
                {
                    case "viagens":
                        var viagens = _context.Relatorio_Viagens.FromSqlRaw($"sp_relatorio_viagem").ToList();
                        path = "./Temp/Relatorios/Relatorio_Viagens.csv";
                        using (StreamWriter streamWriter = System.IO.File.AppendText(path))
                        {
                            streamWriter.WriteLine("Chamado;Cliente;Motorista;Placa_Veiculo;Destino;Custo_Total;Data_Viagem;Status");
                            foreach (var row in viagens)
                            {
                                streamWriter.WriteLine(row.Chamado + ";" + row.Cliente + ";" + row.Motorista + ";" + row.Placa_Veiculo + ";" + row.Destino + ";" 
                                    + "R$ " + row.Custo_Total + ";" + row.Data_Viagem + ";" + row.Status);
                            }

                        }
                        SendReport(path, relatorio.email);
                        break;
                    case "gastosviagem":
                        var gastosviagem = _context.Relatorio_Custo_Viagens.FromSqlRaw($"sp_relatorio_custo_viagem").ToList();
                        path = "./Temp/Relatorios/Relatorio_Gastos_Viagem.csv";
                        using (StreamWriter streamWriter = System.IO.File.AppendText(path))
                        {
                            streamWriter.WriteLine("Chamado;Cliente;Custo_Total;Data_Viagem");
                            foreach (var row in gastosviagem)
                            {
                                streamWriter.WriteLine(row.Chamado + ";" + row.Cliente + ";" + "R$ " + row.Custo_Total + ";" + row.Data_Viagem);
                            }

                        }
                        SendReport(path, relatorio.email);
                        break;
                    case "gastos":
                        var gastos = _context.Relatorio_Gastos.FromSqlRaw($"sp_relatorio_gastos").ToList();
                        path = "./Temp/Relatorios/Relatorio_Gastos.csv";
                        using (StreamWriter streamWriter = System.IO.File.AppendText(path))
                        {
                            streamWriter.WriteLine("Cliente;Numero_Chamados;Custo_Total");
                            foreach (var row in gastos)
                            {
                                streamWriter.WriteLine(row.Cliente + ";" + row.Numero_Chamados + ";" + "R$ " + row.Custo_Total);
                            }
                        }
                        SendReport(path, relatorio.email);
                        break;
                    case "manutencao":
                        var manutencao = _context.Relatorio_Manutencao.FromSqlRaw($"sp_relatorio_manutencao").ToList();
                        path = "./Temp/Relatorios/Relatorio_Manutencao.csv";
                        using (StreamWriter streamWriter = System.IO.File.AppendText(path))
                        {
                            streamWriter.WriteLine("Ordem_Servico;Veiculo;Cliente;Tipo_Manutencao;Custo_Manutencao;Data_Manutencao");
                            foreach (var row in manutencao)
                            {
                                streamWriter.WriteLine(row.Ordem_Servico + ";" + row.Veiculo + ";" + row.Cliente + ";" + row.Tipo_Manutencao + ";" + row.Custo_Manutencao
                                     + ";" + row.Data_Manutencao);
                            }
                        }
                        SendReport(path, relatorio.email);
                        break;
                    case "clientexmotorista":
                        var clientexmotorista = _context.Relatorio_Cliente_x_Motorista.FromSqlRaw($"sp_relatorio_cliente_x_motorista").ToList();
                        path = "./Temp/Relatorios/Relatorio_Cliente_x_Motorista.csv";
                        using (StreamWriter streamWriter = System.IO.File.AppendText(path))
                        {
                            streamWriter.WriteLine("Cliente;Motorista");
                            foreach (var row in clientexmotorista)
                            {
                                streamWriter.WriteLine(row.Cliente + ";" + row.Motorista);
                            }
                        }
                        SendReport(path, relatorio.email);
                        break;
                    case "clientexveiculo":
                        var clientexveiculo = _context.Relatorio_Cliente_x_Veiculo.FromSqlRaw($"sp_relatorio_cliente_x_veiculo").ToList();

                        path = "./Temp/Relatorios/Relatorio_Cliente_x_Veiculo.csv";
                        using (StreamWriter streamWriter = System.IO.File.AppendText(path))
                        {
                            streamWriter.WriteLine("Cliente;Veiculo;Status");
                            foreach (var row in clientexveiculo)
                            {
                                streamWriter.WriteLine(row.Cliente + ";" + row.Veiculo + ";" + row.Status_Veiculo);
                            }
                        }
                        SendReport(path, relatorio.email);
                        break;
                    default:
                        break;
                }
                return RedirectToAction(nameof(Create));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SendReport(string path, string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("netcar.contato@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Relatório";
                mail.IsBodyHtml = true;
                mail.Body = "<p style='font-size: 15pt;'>Segue em anexo relatório solicitado pela plataforma.</p>\n\n<p style='font-weight: bold; font-size: 15pt;'>Por favor não responder esse e-mail!</p>";
                

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(path);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("netcar.contato@gmail.com", "snkfate1575");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}