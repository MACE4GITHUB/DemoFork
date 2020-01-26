export * from './audio.service';
import { AudioService } from './audio.service';
export * from './comment.service';
import { CommentService } from './comment.service';
export * from './content.service';
import { ContentService } from './content.service';
export * from './course.service';
import { CourseService } from './course.service';
export * from './user.service';
import { UserService } from './user.service';
export const APIS = [AudioService, CommentService, ContentService, CourseService, UserService];
