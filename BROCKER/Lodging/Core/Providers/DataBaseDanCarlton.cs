using Microsoft.EntityFrameworkCore;
using MoteeQueso.BROCKER.Lodging.Core.Factories;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Data;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using System;
using System.Threading.Tasks;

namespace MoteeQueso.BROCKER.Lodging.Core.Providers
{
    public class DataBaseDanCarlton : DataBaseFactory
    {
        public override async Task<bool> Cancel(reserve reserve)
        {
            touresbalon_reservations touresbalon_Reservations = new touresbalon_reservations
            {
                order_id = reserve.order_id.ToString(),
                hotel_id = reserve.hotel_id,
                room_number = reserve.room_number,
                check_in_date = reserve.check_in_date,
                check_out_date = reserve.check_out_date,
                state = reserve.state,
                guest_name = reserve.guest_name
            };

            using (DanCarltonEntities entities = new DanCarltonEntities())
            {
                entities.Entry(touresbalon_Reservations).State = EntityState.Modified;
                await entities.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Reserve(reserve reserve)
        {
            touresbalon_reservations touresbalon_Reservations = new touresbalon_reservations
            {
                order_id = reserve.order_id.ToString(),
                hotel_id = reserve.hotel_id,
                room_number = reserve.room_number,
                check_in_date = reserve.check_in_date,
                check_out_date = reserve.check_out_date,
                state = reserve.state,
                guest_name = reserve.guest_name
            };

            using (DanCarltonEntities entities = new DanCarltonEntities())
            {
                entities.touresbalon_reservations.Add(touresbalon_Reservations);
                await entities.SaveChangesAsync();
            }

            return true;
        }
    }
}