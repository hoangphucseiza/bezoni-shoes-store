const host = "https://localhost:7197";

export enum HttpMethods {
  GET = "GET",
  POST = "POST",
  PUT = "PUT",
  DELETE = "DELETE",
  PATCH = "PATCH",
}

export const callApi = async (url : string, method : HttpMethods, body? : any, token?: string) => {
  const res = await $fetch(`${host}/api/${url}`, {
    method: method,
    headers: {
      Authorization: `Bearer ${token}`,
    },
    body: body,
  });
  return res;
}