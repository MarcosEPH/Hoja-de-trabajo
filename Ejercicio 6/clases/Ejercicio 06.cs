using System;
using System.Collections.Generic;

abstract class DocumentoFiscal
{
    public string Numero { get; set; }

    public DocumentoFiscal(string numero)
    {
        Numero = numero;
    }

    public abstract void GenerarPDF();
}

class Factura : DocumentoFiscal
{
    public Factura(string numero) : base(numero) { }

    public override void GenerarPDF()
    {
        Console.WriteLine("PDF Factura: " + Numero);
    }
}

class NotaCredito : DocumentoFiscal
{
    public NotaCredito(string numero) : base(numero) { }

    public override void GenerarPDF()
    {
        Console.WriteLine("PDF Nota de Crédito: " + Numero);
    }
}

class NotaDebito : DocumentoFiscal
{
    public NotaDebito(string numero) : base(numero) { }

    public override void GenerarPDF()
    {
        Console.WriteLine("PDF Nota de Débito: " + Numero);
    }
}

class GestorDocumentos
{
    public void GenerarPDFs(List<DocumentoFiscal> docs)
    {
        foreach (var doc in docs)
        {
            doc.GenerarPDF();
        }
    }
}

class Program
{
    static void Main()
    {
        var documentos = new List<DocumentoFiscal>
        {
            new Factura("001"),
            new NotaCredito("002"),
            new NotaDebito("003")
        };

        var gestor = new GestorDocumentos();
        gestor.GenerarPDFs(documentos);
    }
}