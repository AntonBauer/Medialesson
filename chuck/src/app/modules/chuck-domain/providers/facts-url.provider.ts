import { environment } from './../../../../environments/environment';
import { Provider } from '@angular/core';
import { FACTS_URL } from '../injection-tokens/injection-tokens';

export const factsProvider: Provider = {
  provide: FACTS_URL,
  useValue: environment.factsHostUrl
}
