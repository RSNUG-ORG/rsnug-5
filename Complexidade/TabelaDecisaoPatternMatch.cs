using System;

namespace rsnug_5.Complexidade
{
    class AppointmentPatternMatch
    {
        private const bool F = false;
        private const bool T = true;

        public readonly bool IsAllDay;
        public readonly bool IsRecurrent;
        public readonly bool HasConflict;
        public readonly bool HasAdjactentMeeting;
        public readonly bool IsSafityMinimalDuraton;
        public readonly bool IsSatifyMinimalParticipantNumber;
        public readonly bool IsEvent;

        public AppointmentPatternMatch(bool isAllDay, bool isRecurrent, bool hasConflict, bool hasAdjactentMeeting, bool isSafityMinimalDuraton, bool isSatifyMinimalParticipantNumber, bool isEvent)
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
        public bool Decide() =>
            (IsAllDay, IsRecurrent, HasConflict, HasAdjactentMeeting, IsSafityMinimalDuraton, IsSatifyMinimalParticipantNumber, IsEvent) switch
            {
                (T, _, _, _, _, _, _) => DeclineMeeting(),
                (_, T, _, _, _, _, _) => DeclineMeeting(),
                (F, F, T, _, _, _, _) => DeclineMeeting(),
                (F, F, F, _, F, _, _) => DeclineMeeting(),
                (F, F, F, _, T, F, _) when !IsEvent => DeclineMeeting(),
                (F, F, F, _, T, T, _) => AccepMeeting(),
                (F, F, F, _, T, _, T) => AccepMeeting(),
                _ => DeclineMeeting()
            };

        static bool AccepMeeting() =>
            throw new NotImplementedException();

        static bool DeclineMeeting() =>
            throw new NotImplementedException();
    }
}
