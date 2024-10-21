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
// export const postDataAPI = async (url : string, body : any, token?: string)  => {
//     const res = await $fetch(`${host}/api/${url}`, {
//       method: "POST",
//       headers: {
//         Authorization: `Bearer ${token}`,
//       },
//       body: body,
//     });
//     return res 
// };

// export const getDataAPI = async (url : string, token?: string) => {
//   const res = await $fetch(`${host}/api/${url}`, {
//     method: "GET",
//     headers: {
//       Authorization: `Bearer ${token}`,
//     },
//   });
//   return res;
// };

// export const putDataAPI = async (url : string, body : any, token?: string) => {
//   const res = await $fetch(`${host}/api/${url}`, {
//     method: "PUT",
//     headers: {
//       Authorization: `Bearer ${token}`,
//     },
//     body: body,
//   });
//   return res;
// };

// export const deleteDataAPI = async (url : string, token?: string) => {
//   const res = await $fetch(`${host}/api/${url}`, {
//     method: "DELETE",
//     headers: {
//       Authorization: `Bearer ${token}`,
//     },
//   });
//   return res;
// }

// export const patchDataAPI = async (url : string, body : any, token?: string) => 
// {
//   const res = await $fetch(`${host}/api/${url}`, {
//     method: "PATCH",
//     headers: {
//       Authorization: `Bearer ${token}`,
//     },
//     body: body,
//   })
// }