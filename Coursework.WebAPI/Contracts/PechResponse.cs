namespace Coursework.WebAPI.Contracts
{
    public record PechResponse
    (
        Guid Id,
        float tPech, 
        float diametr,
        float tNach,
        float kTeplo,
        float p,
        float tPov,
        float kPer,
        float T
    );
}
