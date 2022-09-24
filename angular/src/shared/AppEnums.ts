export class AppEditionExpireAction {
    static DeactiveTenant = 'DeactiveTenant';
    static AssignToAnotherEdition = 'AssignToAnotherEdition';
}

export class ActivitySourceType {
    static LEAD = 'LEAD';
    static ACCOUNT = 'ACCOUNT';
    static OPPORTUNITY = 'OPPORTUNITY';
}

export class ActivityTaskType {
    static SCHEDULE_MEETING = 'SCHEDULE_MEETING';
    static SCHEDULE_CALL = 'SCHEDULE_CALL';
    static EMAIL_REMINDER = 'EMAIL_REMINDER';
    static TODO_REMINDER = 'TODO_REMINDER';
}

export enum ActivityDuration {
    FifteenMinutes,
    ThirtyMinutes,
    OneHour,
    OneHourAndThirtyMinutes,
    TwoHours,
}

export enum PageMode {
    Add = 1,
    View,
    Edit
}
