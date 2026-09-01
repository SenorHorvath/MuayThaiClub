export class AuthLoginResultDto {
    accessToken : string = ''
    accesTokenExpiration : Date = new Date()
    refreshToken : string = ''
    refreshTokenExpiration : Date = new Date()
}
