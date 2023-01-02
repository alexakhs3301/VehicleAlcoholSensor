using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAlcoholSensor.Application.Abstraction
{
    public interface IHandler<TResult>
    {
        public Task<TResult> HandleAsync(ICommand entity);
    }
}
