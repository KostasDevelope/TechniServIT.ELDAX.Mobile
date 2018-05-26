export interface Function{
    Signature: string;
    Route: string;
    HttpMethod: string;
    Example: string;
}
export interface FunctionArray extends Array<Function>{}

export interface ControllersInfo {
    Name: string;
    ModuleName: string;
    Namespace: string;
    Functions: FunctionArray;
}
export interface ControllersInfoArray extends Array<ControllersInfo>{}

export interface ApiVersion {
    clientVersion: string;
}



