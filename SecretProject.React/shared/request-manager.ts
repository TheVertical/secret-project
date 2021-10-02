import ExtraInformation from "@/models/extra-information";
import ToasterHelper from "./helpers/toaster-helper";
import LocalizeService from "./localization-service";

export enum HttpMethod {
     Get = 'GET',
     Post = 'POST',
}

const RequestManager = {
     sendRequest: async function (httpMethod: HttpMethod, url: string, params: Record<string, string> | undefined = undefined, payload: any = undefined): Promise<any> {
          const requestSettings: RequestInit = {
               method: httpMethod,
               body: JSON.stringify(payload),
               headers: {
                    'Content-Type': 'application/json'
               }
          };

          var responce = await fetch(url, requestSettings);

          let result: ExtraInformation | null = await responce.json() as ExtraInformation;
          
          if (result == null) {
               ToasterHelper.addErrorToasts(LocalizeService.localize("Error"), LocalizeService.localize("Error"));
               return null;
          }

          if(result.Message)
          {
               ToasterHelper.addToast(result.Message, result.Title, result.Type);
          }

          result.Data;
     }
}

export default RequestManager;