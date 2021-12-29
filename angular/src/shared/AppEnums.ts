export class AppEditionExpireAction {
    static DeactiveTenant = 'DeactiveTenant';
    static AssignToAnotherEdition = 'AssignToAnotherEdition';
}

export enum ActivitySourceType {
    Lead,
    Account,
    Opportunity,
}

export enum ActivityTaskType {
    ScheduleMeeting,
    ScheduleCall,
    EmailReminder,
    ToDoReminder,
}

export enum ActivityDuration {
    FifteenMinutes,
    ThirtyMinutes,
    OneHour,
    OneHourAndThirtyMinutes,
    TwoHours,
}

export const getActivityDurationIitems = () => [
    {
        text: '15 Minutes',
        value: 15,
        enumValue: ActivityDuration.FifteenMinutes,
    },
    {
        text: '30 Minutes',
        value: 30,
        enumValue: ActivityDuration.ThirtyMinutes,
    },
    {
        text: '1 Hour',
        value: 60,
        enumValue: ActivityDuration.OneHour,
    },
    {
        text: '1.5 Hours',
        value: 90,
        enumValue: ActivityDuration.OneHourAndThirtyMinutes,
    },
    {
        text: '2 Hours',
        value: 120,
        enumValue: ActivityDuration.TwoHours,
    },
];
