using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDigit.Documento;

public abstract class Documento(Func<int, int> computeMultiplier, Func<long, int> computeDigit) : Modulus11Compute(computeMultiplier, computeDigit)
{
    #region ICompute members

    /// <summary>
    /// Calcula dígito de documento.
    /// </summary>
    /// <param name="cpf">Número do documento</param>
    /// <returns>Dígito do documento</returns>
    public override int Calculate(long cpf)
    {
        int digito = base.Calculate(cpf);
        cpf = cpf * 10 + digito;
        return digito * 10 + base.Calculate(cpf);
    }

    #endregion
}
