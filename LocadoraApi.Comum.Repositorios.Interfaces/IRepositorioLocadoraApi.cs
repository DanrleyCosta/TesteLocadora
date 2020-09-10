﻿using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LocadoraApi.Comum.Repositorios.Interfaces
{
    // O objetivo desta interface e ser usada em toda a api, por isso foi criado um parametro genérico (TDominio) que poderá ser apenas uma classe
    public interface IRepositorioLocadoraApi<TDominio, TChave> where TDominio : class
    {
        //inicia como null
        List<TDominio> Selecionar(Expression<Func<TDominio, bool>> where = null);
        TDominio SelecionarPorId(TChave id);
        void Inserir(TDominio dominio);
        void Atualizar(TDominio dominio);
    }
}