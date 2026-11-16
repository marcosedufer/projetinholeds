using System;

namespace projetinholeds
{
    internal class Leds
    {
        private byte status;

        public Leds()
        {
            this.status = 0;
        }

        public Leds(byte status)
        {
            this.status = status;
        }

        // liga o bit (0 a 7) com OR
        public void acender(int led)
        {
            if (led < 0 || led > 7) return;
            this.status = (byte)(this.status | (1 << led));
        }

        // desliga o bit (0 a 7) com AND e máscara invertida
        public void apagar(int led)
        {
            if (led < 0 || led > 7) return;
            this.status = (byte)(this.status & ~(1 << led));
        }

        public byte getStatus()
        {
            return this.status;
        }

        // true se o bit (0 a 7) estiver aceso
        public bool getStatus(int led)
        {
            if (led < 0 || led > 7) return false;
            return (this.status & (1 << led)) != 0;
        }
    }
}