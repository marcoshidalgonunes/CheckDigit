namespace CheckDigit;

/// <summary>
/// Interface para cálculo de CNPJ
/// </summary>
public interface ICNPJCompute : ICompute
{
    /// <summary>
    /// Calcula dígito de CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <param name="filial">Filial do PJ</param>
    /// <returns>Dígito do CNPJ</returns>
    int Calculate(long cnpj, int filial);

    /// <summary>
    /// Calcula dígito de CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <param name="filial">Filial do PJ</param>
    /// <returns>Dígito do CNPJ</returns>
    string Calculate(string cnpj, string filial);

    /// <summary>
    /// Valida número do CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <param name="filial">Filial do PJ</param>
    /// <param name="dv">Dígito do CNPJ</param>
    /// <returns>True para número do CNPJ válido</returns>
    bool Validate(long cnpj, int filial, int digito);

    /// <summary>
    /// Valida número do CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <param name="filial">Filial do PJ</param>
    /// <param name="dv">Dígito do CNPJ</param>
    /// <returns>True para número do CNPJ válido</returns>
    bool Validate(string cnpj, string filial, string digito);
}
