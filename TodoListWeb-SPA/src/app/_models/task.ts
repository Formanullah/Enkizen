import { User } from './user';
export interface Task {
    id: number;
    taskName: string;
    userId: number;
    createdDate?: Date;
    updateDate?: Date;
    deletedDate?: Date;
    isDeleted?: boolean;
    isDone?: boolean;
    user: User;
}
