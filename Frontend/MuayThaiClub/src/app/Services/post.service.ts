import { Injectable } from '@angular/core';
import { environment } from '../Environments/environment';
import { HttpClient } from '@angular/common/http';
import { PostCreateUpdateDto } from '../Model/Post/post-create-update-dto';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private apiUrl : string = environment.apiUrl + '/Post/'
  
  constructor(private client : HttpClient) {
  }
  
  createPost(dto : PostCreateUpdateDto)
  {
    return this.client.post(this.apiUrl, dto, { withCredentials : true})
  }
  
  getAll()
  {
    return []
  }
}
