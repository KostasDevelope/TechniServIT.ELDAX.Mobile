export interface ControllersInfo {
    Name: string;
    ModuleName: string;
    Namespace: string;
    Functions: Array<Function>;
}

export interface Function{
    Signature: string;
    Route: string;
    HttpMethod: string;
    Example: string;
}