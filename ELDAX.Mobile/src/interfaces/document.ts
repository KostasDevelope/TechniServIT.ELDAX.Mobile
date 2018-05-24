import { DateTime } from "ionic-angular";

export interface Document {
    Id : string;
    Created: DateTime;
    CreatedBy: string;
    Modified: DateTime;
    ModifiedBy: string;
    StorageId: string;
    StorageName: string;
    DocumentClassId: string;
    DocumentClassName: string;
    PackageId: string;
    ShreddingTypeId: string;
    DocumentTypeName: string;
    SourceSystem: string;
    Name: string;
    FileName: string;
    DocumentContentId: string;
    MimeType: string;
    ExpirationDate: string;
    LastTimeStampInfoId: string;
    LastStatusCheck: string;
    KeyWords: string;
    Description: string;
    Extension: string;
    HashAlgorithm: string;
    OriginalHash: string;
    Content: object
    Period: string;
    ShreddingRuleCharacter: string;
    StatusName: string;
    LastError: string;
    IsExclusiveAccess: boolean;
    ShreddingActivationStart: string; 
    ShreddingActivationType: string;
    ShreddingActivationDateStart: string;
    ShreddingActivationId: string;
    LastErrorDescription: string;
    Character: string;
    ShreddingStart: string;
    Expiration: string;
    ShreddingDate: string;
    CaseId: string;
    IsCollection: string; 
    Path: string;
    ReplicationPath: string;
    IsVerificationDocument: boolean
    VersionHolder: object
    LastHashCheck: string;
}
export interface DocumentArray extends Array<Document>{}