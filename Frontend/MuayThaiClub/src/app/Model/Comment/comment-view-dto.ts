export class CommentViewDto {
    id : string = ''
    message : string = ''
    parentCommentID = ''
    creatorID : string = ''
    createdAt : string = ''
    replies : CommentViewDto[] = []
}
