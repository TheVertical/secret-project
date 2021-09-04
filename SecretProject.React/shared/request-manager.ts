import ExtraInformation from "@/models/extra-information";
import ToasterHelper from "./helpers/toaster-helper";
import LocalizeService from "./localization-service";

export enum HttpMethod {
     Get = 'GET',
     Post = 'POST',
}

const RequestManager = {
     sendRequest: async function (httpMethod: HttpMethod, url: string, params: Record<string, string> | undefined = undefined, payload: any = undefined): Promise<any> {

          const resultUrl = new URL(url);
          resultUrl.search = (new URLSearchParams(params)).toString();
          const jsonPayload = JSON.stringify(payload);
          const requestSettings: RequestInit = {
               method: httpMethod,
               body: JSON.stringify(jsonPayload),
          };

          var responce = await fetch(url, requestSettings);

          let result: ExtraInformation | null = await responce.json() as ExtraInformation;
          debugger;
          if (result == null) {
               ToasterHelper.addErrorToasts([LocalizeService.localize("Error")]);
               return null;
          }

          result.Data;
     }
}

export default RequestManager;