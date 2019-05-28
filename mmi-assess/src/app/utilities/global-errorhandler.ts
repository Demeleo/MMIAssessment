import { ErrorHandler, Injectable } from '@angular/core';

import { NotificationService } from '../services/notification.service';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
     constructor(private notifyService: NotificationService) {}

     handleError(error) {
        this.notifyService.showError(JSON.stringify({
            code: error.status,
            text: error.statusText,
            error: error.error,
            body: error.message,
            url: error.url
       }));
     }
}
