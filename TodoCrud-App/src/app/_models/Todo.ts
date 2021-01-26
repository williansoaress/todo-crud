import { User } from "./User";

export interface Todo {
    id: number;
    name: string;
    dueDate: string;
    isComplete: boolean;

    userId: number;
    user: User;

}
