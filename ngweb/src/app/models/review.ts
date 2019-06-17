import { Channel } from './channel';
import { User } from './user';

export class Review {
    id?: number;
    text: string;
    rating: number;
    date: Date;
    
    userId?: number;
    user?: User;
    channelId?: number;
    channel?: Channel;
}