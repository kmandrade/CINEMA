﻿using FluentResults;

namespace Testes.BaseEntities
{
    public static class TesteRepository
    {


        public static bool Retorna_FalseInFalid_TrueInSucess_Result(Result resultado)
        {
            if (resultado.IsFailed)
            {
                return false;
            }
            return true;
        }


    }
}
