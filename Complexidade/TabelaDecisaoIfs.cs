using System;
using System.Collections.Generic;
using System.Text;

namespace rsnug_5.Complexidade
{
    class AppointmentIf
    {
        public readonly bool IsAllDay;
        public readonly bool IsRecurrent;
        public readonly bool HasConflict;
        public readonly bool HasAdjactentMeeting;
        public readonly bool IsSafityMinimalDuraton;
        public readonly bool IsSatifyMinimalParticipantNumber;
        public readonly bool IsEvent;

        public AppointmentIf(bool isAllDay, bool isRecurrent, bool hasConflict, bool hasAdjactentMeeting, bool isSafityMinimalDuraton, bool isSatifyMinimalParticipantNumber, bool isEvent)
        {
            IsAllDay = isAllDay;
            IsRecurrent = isRecurrent;
            HasConflict = hasConflict;
            HasAdjactentMeeting = hasAdjactentMeeting;
            IsSafityMinimalDuraton = isSafityMinimalDuraton;
            IsSatifyMinimalParticipantNumber = isSatifyMinimalParticipantNumber;
            IsEvent = isEvent;
        }

        // Regras para agendar uma reunião
        // -- Não permitir reuniões menores de 40 minutos
        // -- Não permitir reuniões com menos de 5 pessoas
        // -- As reuniões não podem ter conflitos
        // -- As reuniões não podem ser recorrentes
        // -- As reuniões não podem ser de dia inteiro
        // -- Quando for um evento então permitir agendamento com menos de 5 pessoas
        public bool Decide()
        {
            if (!IsAllDay)
            {
                if (!IsRecurrent)
                {
                    if (!HasConflict)
                    {
                        if (IsSafityMinimalDuraton)
                        {
                            if (!IsSatifyMinimalParticipantNumber)
                            {
                                if (IsEvent)
                                {
                                    if (IsEvent)
                                    {
                                        return AccepMeeting();
                                    }
                                    return DeclineMeeting();
                                }
                                return DeclineMeeting();
                            }
                            return AccepMeeting();
                        }
                        return DeclineMeeting();
                    }
                    return DeclineMeeting();
                }
                return DeclineMeeting();
            }
            return DeclineMeeting();
        }

        static bool AccepMeeting() =>
            throw new NotImplementedException();

        static bool DeclineMeeting() =>
            throw new NotImplementedException();
    }
}
