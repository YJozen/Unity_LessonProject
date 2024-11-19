#if !DISABLE_PLAYFABENTITY_API
using PlayFab.MultiplayerModels;

namespace PlayFab.Events
{
    public partial class PlayFabEvents
    {
        public event PlayFabRequestEvent<CancelAllMatchmakingTicketsForPlayerRequest> OnMultiplayerCancelAllMatchmakingTicketsForPlayerRequestEvent;
        public event PlayFabResultEvent<CancelAllMatchmakingTicketsForPlayerResult> OnMultiplayerCancelAllMatchmakingTicketsForPlayerResultEvent;
        public event PlayFabRequestEvent<CancelAllServerBackfillTicketsForPlayerRequest> OnMultiplayerCancelAllServerBackfillTicketsForPlayerRequestEvent;
        public event PlayFabResultEvent<CancelAllServerBackfillTicketsForPlayerResult> OnMultiplayerCancelAllServerBackfillTicketsForPlayerResultEvent;
        public event PlayFabRequestEvent<CancelMatchmakingTicketRequest> OnMultiplayerCancelMatchmakingTicketRequestEvent;
        public event PlayFabResultEvent<CancelMatchmakingTicketResult> OnMultiplayerCancelMatchmakingTicketResultEvent;
        public event PlayFabRequestEvent<CancelServerBackfillTicketRequest> OnMultiplayerCancelServerBackfillTicketRequestEvent;
        public event PlayFabResultEvent<CancelServerBackfillTicketResult> OnMultiplayerCancelServerBackfillTicketResultEvent;
        public event PlayFabRequestEvent<CreateBuildAliasRequest> OnMultiplayerCreateBuildAliasRequestEvent;
        public event PlayFabResultEvent<BuildAliasDetailsResponse> OnMultiplayerCreateBuildAliasResultEvent;
        public event PlayFabRequestEvent<CreateBuildWithCustomContainerRequest> OnMultiplayerCreateBuildWithCustomContainerRequestEvent;
        public event PlayFabResultEvent<CreateBuildWithCustomContainerResponse> OnMultiplayerCreateBuildWithCustomContainerResultEvent;
        public event PlayFabRequestEvent<CreateBuildWithManagedContainerRequest> OnMultiplayerCreateBuildWithManagedContainerRequestEvent;
        public event PlayFabResultEvent<CreateBuildWithManagedContainerResponse> OnMultiplayerCreateBuildWithManagedContainerResultEvent;
        public event PlayFabRequestEvent<CreateBuildWithProcessBasedServerRequest> OnMultiplayerCreateBuildWithProcessBasedServerRequestEvent;
        public event PlayFabResultEvent<CreateBuildWithProcessBasedServerResponse> OnMultiplayerCreateBuildWithProcessBasedServerResultEvent;
        public event PlayFabRequestEvent<CreateLobbyRequest> OnMultiplayerCreateLobbyRequestEvent;
        public event PlayFabResultEvent<CreateLobbyResult> OnMultiplayerCreateLobbyResultEvent;
        public event PlayFabRequestEvent<CreateMatchmakingTicketRequest> OnMultiplayerCreateMatchmakingTicketRequestEvent;
        public event PlayFabResultEvent<CreateMatchmakingTicketResult> OnMultiplayerCreateMatchmakingTicketResultEvent;
        public event PlayFabRequestEvent<CreateRemoteUserRequest> OnMultiplayerCreateRemoteUserRequestEvent;
        public event PlayFabResultEvent<CreateRemoteUserResponse> OnMultiplayerCreateRemoteUserResultEvent;
        public event PlayFabRequestEvent<CreateServerBackfillTicketRequest> OnMultiplayerCreateServerBackfillTicketRequestEvent;
        public event PlayFabResultEvent<CreateServerBackfillTicketResult> OnMultiplayerCreateServerBackfillTicketResultEvent;
        public event PlayFabRequestEvent<CreateServerMatchmakingTicketRequest> OnMultiplayerCreateServerMatchmakingTicketRequestEvent;
        public event PlayFabResultEvent<CreateMatchmakingTicketResult> OnMultiplayerCreateServerMatchmakingTicketResultEvent;
        public event PlayFabRequestEvent<CreateTitleMultiplayerServersQuotaChangeRequest> OnMultiplayerCreateTitleMultiplayerServersQuotaChangeRequestEvent;
        public event PlayFabResultEvent<CreateTitleMultiplayerServersQuotaChangeResponse> OnMultiplayerCreateTitleMultiplayerServersQuotaChangeResultEvent;
        public event PlayFabRequestEvent<DeleteAssetRequest> OnMultiplayerDeleteAssetRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteAssetResultEvent;
        public event PlayFabRequestEvent<DeleteBuildRequest> OnMultiplayerDeleteBuildRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteBuildResultEvent;
        public event PlayFabRequestEvent<DeleteBuildAliasRequest> OnMultiplayerDeleteBuildAliasRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteBuildAliasResultEvent;
        public event PlayFabRequestEvent<DeleteBuildRegionRequest> OnMultiplayerDeleteBuildRegionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteBuildRegionResultEvent;
        public event PlayFabRequestEvent<DeleteCertificateRequest> OnMultiplayerDeleteCertificateRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteCertificateResultEvent;
        public event PlayFabRequestEvent<DeleteContainerImageRequest> OnMultiplayerDeleteContainerImageRepositoryRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteContainerImageRepositoryResultEvent;
        public event PlayFabRequestEvent<DeleteLobbyRequest> OnMultiplayerDeleteLobbyRequestEvent;
        public event PlayFabResultEvent<LobbyEmptyResult> OnMultiplayerDeleteLobbyResultEvent;
        public event PlayFabRequestEvent<DeleteRemoteUserRequest> OnMultiplayerDeleteRemoteUserRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerDeleteRemoteUserResultEvent;
        public event PlayFabRequestEvent<EnableMultiplayerServersForTitleRequest> OnMultiplayerEnableMultiplayerServersForTitleRequestEvent;
        public event PlayFabResultEvent<EnableMultiplayerServersForTitleResponse> OnMultiplayerEnableMultiplayerServersForTitleResultEvent;
        public event PlayFabRequestEvent<FindFriendLobbiesRequest> OnMultiplayerFindFriendLobbiesRequestEvent;
        public event PlayFabResultEvent<FindFriendLobbiesResult> OnMultiplayerFindFriendLobbiesResultEvent;
        public event PlayFabRequestEvent<FindLobbiesRequest> OnMultiplayerFindLobbiesRequestEvent;
        public event PlayFabResultEvent<FindLobbiesResult> OnMultiplayerFindLobbiesResultEvent;
        public event PlayFabRequestEvent<GetAssetDownloadUrlRequest> OnMultiplayerGetAssetDownloadUrlRequestEvent;
        public event PlayFabResultEvent<GetAssetDownloadUrlResponse> OnMultiplayerGetAssetDownloadUrlResultEvent;
        public event PlayFabRequestEvent<GetAssetUploadUrlRequest> OnMultiplayerGetAssetUploadUrlRequestEvent;
        public event PlayFabResultEvent<GetAssetUploadUrlResponse> OnMultiplayerGetAssetUploadUrlResultEvent;
        public event PlayFabRequestEvent<GetBuildRequest> OnMultiplayerGetBuildRequestEvent;
        public event PlayFabResultEvent<GetBuildResponse> OnMultiplayerGetBuildResultEvent;
        public event PlayFabRequestEvent<GetBuildAliasRequest> OnMultiplayerGetBuildAliasRequestEvent;
        public event PlayFabResultEvent<BuildAliasDetailsResponse> OnMultiplayerGetBuildAliasResultEvent;
        public event PlayFabRequestEvent<GetContainerRegistryCredentialsRequest> OnMultiplayerGetContainerRegistryCredentialsRequestEvent;
        public event PlayFabResultEvent<GetContainerRegistryCredentialsResponse> OnMultiplayerGetContainerRegistryCredentialsResultEvent;
        public event PlayFabRequestEvent<GetLobbyRequest> OnMultiplayerGetLobbyRequestEvent;
        public event PlayFabResultEvent<GetLobbyResult> OnMultiplayerGetLobbyResultEvent;
        public event PlayFabRequestEvent<GetMatchRequest> OnMultiplayerGetMatchRequestEvent;
        public event PlayFabResultEvent<GetMatchResult> OnMultiplayerGetMatchResultEvent;
        public event PlayFabRequestEvent<GetMatchmakingQueueRequest> OnMultiplayerGetMatchmakingQueueRequestEvent;
        public event PlayFabResultEvent<GetMatchmakingQueueResult> OnMultiplayerGetMatchmakingQueueResultEvent;
        public event PlayFabRequestEvent<GetMatchmakingTicketRequest> OnMultiplayerGetMatchmakingTicketRequestEvent;
        public event PlayFabResultEvent<GetMatchmakingTicketResult> OnMultiplayerGetMatchmakingTicketResultEvent;
        public event PlayFabRequestEvent<GetMultiplayerServerDetailsRequest> OnMultiplayerGetMultiplayerServerDetailsRequestEvent;
        public event PlayFabResultEvent<GetMultiplayerServerDetailsResponse> OnMultiplayerGetMultiplayerServerDetailsResultEvent;
        public event PlayFabRequestEvent<GetMultiplayerServerLogsRequest> OnMultiplayerGetMultiplayerServerLogsRequestEvent;
        public event PlayFabResultEvent<GetMultiplayerServerLogsResponse> OnMultiplayerGetMultiplayerServerLogsResultEvent;
        public event PlayFabRequestEvent<GetMultiplayerSessionLogsBySessionIdRequest> OnMultiplayerGetMultiplayerSessionLogsBySessionIdRequestEvent;
        public event PlayFabResultEvent<GetMultiplayerServerLogsResponse> OnMultiplayerGetMultiplayerSessionLogsBySessionIdResultEvent;
        public event PlayFabRequestEvent<GetQueueStatisticsRequest> OnMultiplayerGetQueueStatisticsRequestEvent;
        public event PlayFabResultEvent<GetQueueStatisticsResult> OnMultiplayerGetQueueStatisticsResultEvent;
        public event PlayFabRequestEvent<GetRemoteLoginEndpointRequest> OnMultiplayerGetRemoteLoginEndpointRequestEvent;
        public event PlayFabResultEvent<GetRemoteLoginEndpointResponse> OnMultiplayerGetRemoteLoginEndpointResultEvent;
        public event PlayFabRequestEvent<GetServerBackfillTicketRequest> OnMultiplayerGetServerBackfillTicketRequestEvent;
        public event PlayFabResultEvent<GetServerBackfillTicketResult> OnMultiplayerGetServerBackfillTicketResultEvent;
        public event PlayFabRequestEvent<GetTitleEnabledForMultiplayerServersStatusRequest> OnMultiplayerGetTitleEnabledForMultiplayerServersStatusRequestEvent;
        public event PlayFabResultEvent<GetTitleEnabledForMultiplayerServersStatusResponse> OnMultiplayerGetTitleEnabledForMultiplayerServersStatusResultEvent;
        public event PlayFabRequestEvent<GetTitleMultiplayerServersQuotaChangeRequest> OnMultiplayerGetTitleMultiplayerServersQuotaChangeRequestEvent;
        public event PlayFabResultEvent<GetTitleMultiplayerServersQuotaChangeResponse> OnMultiplayerGetTitleMultiplayerServersQuotaChangeResultEvent;
        public event PlayFabRequestEvent<GetTitleMultiplayerServersQuotasRequest> OnMultiplayerGetTitleMultiplayerServersQuotasRequestEvent;
        public event PlayFabResultEvent<GetTitleMultiplayerServersQuotasResponse> OnMultiplayerGetTitleMultiplayerServersQuotasResultEvent;
        public event PlayFabRequestEvent<InviteToLobbyRequest> OnMultiplayerInviteToLobbyRequestEvent;
        public event PlayFabResultEvent<LobbyEmptyResult> OnMultiplayerInviteToLobbyResultEvent;
        public event PlayFabRequestEvent<JoinArrangedLobbyRequest> OnMultiplayerJoinArrangedLobbyRequestEvent;
        public event PlayFabResultEvent<JoinLobbyResult> OnMultiplayerJoinArrangedLobbyResultEvent;
        public event PlayFabRequestEvent<JoinLobbyRequest> OnMultiplayerJoinLobbyRequestEvent;
        public event PlayFabResultEvent<JoinLobbyResult> OnMultiplayerJoinLobbyResultEvent;
        public event PlayFabRequestEvent<JoinLobbyAsServerRequest> OnMultiplayerJoinLobbyAsServerRequestEvent;
        public event PlayFabResultEvent<JoinLobbyAsServerResult> OnMultiplayerJoinLobbyAsServerResultEvent;
        public event PlayFabRequestEvent<JoinMatchmakingTicketRequest> OnMultiplayerJoinMatchmakingTicketRequestEvent;
        public event PlayFabResultEvent<JoinMatchmakingTicketResult> OnMultiplayerJoinMatchmakingTicketResultEvent;
        public event PlayFabRequestEvent<LeaveLobbyRequest> OnMultiplayerLeaveLobbyRequestEvent;
        public event PlayFabResultEvent<LobbyEmptyResult> OnMultiplayerLeaveLobbyResultEvent;
        public event PlayFabRequestEvent<LeaveLobbyAsServerRequest> OnMultiplayerLeaveLobbyAsServerRequestEvent;
        public event PlayFabResultEvent<LobbyEmptyResult> OnMultiplayerLeaveLobbyAsServerResultEvent;
        public event PlayFabRequestEvent<ListMultiplayerServersRequest> OnMultiplayerListArchivedMultiplayerServersRequestEvent;
        public event PlayFabResultEvent<ListMultiplayerServersResponse> OnMultiplayerListArchivedMultiplayerServersResultEvent;
        public event PlayFabRequestEvent<ListAssetSummariesRequest> OnMultiplayerListAssetSummariesRequestEvent;
        public event PlayFabResultEvent<ListAssetSummariesResponse> OnMultiplayerListAssetSummariesResultEvent;
        public event PlayFabRequestEvent<ListBuildAliasesRequest> OnMultiplayerListBuildAliasesRequestEvent;
        public event PlayFabResultEvent<ListBuildAliasesResponse> OnMultiplayerListBuildAliasesResultEvent;
        public event PlayFabRequestEvent<ListBuildSummariesRequest> OnMultiplayerListBuildSummariesV2RequestEvent;
        public event PlayFabResultEvent<ListBuildSummariesResponse> OnMultiplayerListBuildSummariesV2ResultEvent;
        public event PlayFabRequestEvent<ListCertificateSummariesRequest> OnMultiplayerListCertificateSummariesRequestEvent;
        public event PlayFabResultEvent<ListCertificateSummariesResponse> OnMultiplayerListCertificateSummariesResultEvent;
        public event PlayFabRequestEvent<ListContainerImagesRequest> OnMultiplayerListContainerImagesRequestEvent;
        public event PlayFabResultEvent<ListContainerImagesResponse> OnMultiplayerListContainerImagesResultEvent;
        public event PlayFabRequestEvent<ListContainerImageTagsRequest> OnMultiplayerListContainerImageTagsRequestEvent;
        public event PlayFabResultEvent<ListContainerImageTagsResponse> OnMultiplayerListContainerImageTagsResultEvent;
        public event PlayFabRequestEvent<ListMatchmakingQueuesRequest> OnMultiplayerListMatchmakingQueuesRequestEvent;
        public event PlayFabResultEvent<ListMatchmakingQueuesResult> OnMultiplayerListMatchmakingQueuesResultEvent;
        public event PlayFabRequestEvent<ListMatchmakingTicketsForPlayerRequest> OnMultiplayerListMatchmakingTicketsForPlayerRequestEvent;
        public event PlayFabResultEvent<ListMatchmakingTicketsForPlayerResult> OnMultiplayerListMatchmakingTicketsForPlayerResultEvent;
        public event PlayFabRequestEvent<ListMultiplayerServersRequest> OnMultiplayerListMultiplayerServersRequestEvent;
        public event PlayFabResultEvent<ListMultiplayerServersResponse> OnMultiplayerListMultiplayerServersResultEvent;
        public event PlayFabRequestEvent<ListPartyQosServersRequest> OnMultiplayerListPartyQosServersRequestEvent;
        public event PlayFabResultEvent<ListPartyQosServersResponse> OnMultiplayerListPartyQosServersResultEvent;
        public event PlayFabRequestEvent<ListQosServersForTitleRequest> OnMultiplayerListQosServersForTitleRequestEvent;
        public event PlayFabResultEvent<ListQosServersForTitleResponse> OnMultiplayerListQosServersForTitleResultEvent;
        public event PlayFabRequestEvent<ListServerBackfillTicketsForPlayerRequest> OnMultiplayerListServerBackfillTicketsForPlayerRequestEvent;
        public event PlayFabResultEvent<ListServerBackfillTicketsForPlayerResult> OnMultiplayerListServerBackfillTicketsForPlayerResultEvent;
        public event PlayFabRequestEvent<ListTitleMultiplayerServersQuotaChangesRequest> OnMultiplayerListTitleMultiplayerServersQuotaChangesRequestEvent;
        public event PlayFabResultEvent<ListTitleMultiplayerServersQuotaChangesResponse> OnMultiplayerListTitleMultiplayerServersQuotaChangesResultEvent;
        public event PlayFabRequestEvent<ListVirtualMachineSummariesRequest> OnMultiplayerListVirtualMachineSummariesRequestEvent;
        public event PlayFabResultEvent<ListVirtualMachineSummariesResponse> OnMultiplayerListVirtualMachineSummariesResultEvent;
        public event PlayFabRequestEvent<RemoveMatchmakingQueueRequest> OnMultiplayerRemoveMatchmakingQueueRequestEvent;
        public event PlayFabResultEvent<RemoveMatchmakingQueueResult> OnMultiplayerRemoveMatchmakingQueueResultEvent;
        public event PlayFabRequestEvent<RemoveMemberFromLobbyRequest> OnMultiplayerRemoveMemberRequestEvent;
        public event PlayFabResultEvent<LobbyEmptyResult> OnMultiplayerRemoveMemberResultEvent;
        public event PlayFabRequestEvent<RequestMultiplayerServerRequest> OnMultiplayerRequestMultiplayerServerRequestEvent;
        public event PlayFabResultEvent<RequestMultiplayerServerResponse> OnMultiplayerRequestMultiplayerServerResultEvent;
        public event PlayFabRequestEvent<RequestPartyServiceRequest> OnMultiplayerRequestPartyServiceRequestEvent;
        public event PlayFabResultEvent<RequestPartyServiceResponse> OnMultiplayerRequestPartyServiceResultEvent;
        public event PlayFabRequestEvent<RolloverContainerRegistryCredentialsRequest> OnMultiplayerRolloverContainerRegistryCredentialsRequestEvent;
        public event PlayFabResultEvent<RolloverContainerRegistryCredentialsResponse> OnMultiplayerRolloverContainerRegistryCredentialsResultEvent;
        public event PlayFabRequestEvent<SetMatchmakingQueueRequest> OnMultiplayerSetMatchmakingQueueRequestEvent;
        public event PlayFabResultEvent<SetMatchmakingQueueResult> OnMultiplayerSetMatchmakingQueueResultEvent;
        public event PlayFabRequestEvent<ShutdownMultiplayerServerRequest> OnMultiplayerShutdownMultiplayerServerRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerShutdownMultiplayerServerResultEvent;
        public event PlayFabRequestEvent<SubscribeToLobbyResourceRequest> OnMultiplayerSubscribeToLobbyResourceRequestEvent;
        public event PlayFabResultEvent<SubscribeToLobbyResourceResult> OnMultiplayerSubscribeToLobbyResourceResultEvent;
        public event PlayFabRequestEvent<SubscribeToMatchResourceRequest> OnMultiplayerSubscribeToMatchmakingResourceRequestEvent;
        public event PlayFabResultEvent<SubscribeToMatchResourceResult> OnMultiplayerSubscribeToMatchmakingResourceResultEvent;
        public event PlayFabRequestEvent<UnsubscribeFromLobbyResourceRequest> OnMultiplayerUnsubscribeFromLobbyResourceRequestEvent;
        public event PlayFabResultEvent<LobbyEmptyResult> OnMultiplayerUnsubscribeFromLobbyResourceResultEvent;
        public event PlayFabRequestEvent<UnsubscribeFromMatchResourceRequest> OnMultiplayerUnsubscribeFromMatchmakingResourceRequestEvent;
        public event PlayFabResultEvent<UnsubscribeFromMatchResourceResult> OnMultiplayerUnsubscribeFromMatchmakingResourceResultEvent;
        public event PlayFabRequestEvent<UntagContainerImageRequest> OnMultiplayerUntagContainerImageRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerUntagContainerImageResultEvent;
        public event PlayFabRequestEvent<UpdateBuildAliasRequest> OnMultiplayerUpdateBuildAliasRequestEvent;
        public event PlayFabResultEvent<BuildAliasDetailsResponse> OnMultiplayerUpdateBuildAliasResultEvent;
        public event PlayFabRequestEvent<UpdateBuildNameRequest> OnMultiplayerUpdateBuildNameRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerUpdateBuildNameResultEvent;
        public event PlayFabRequestEvent<UpdateBuildRegionRequest> OnMultiplayerUpdateBuildRegionRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerUpdateBuildRegionResultEvent;
        public event PlayFabRequestEvent<UpdateBuildRegionsRequest> OnMultiplayerUpdateBuildRegionsRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerUpdateBuildRegionsResultEvent;
        public event PlayFabRequestEvent<UpdateLobbyRequest> OnMultiplayerUpdateLobbyRequestEvent;
        public event PlayFabResultEvent<LobbyEmptyResult> OnMultiplayerUpdateLobbyResultEvent;
        public event PlayFabRequestEvent<UpdateLobbyAsServerRequest> OnMultiplayerUpdateLobbyAsServerRequestEvent;
        public event PlayFabResultEvent<LobbyEmptyResult> OnMultiplayerUpdateLobbyAsServerResultEvent;
        public event PlayFabRequestEvent<UploadCertificateRequest> OnMultiplayerUploadCertificateRequestEvent;
        public event PlayFabResultEvent<EmptyResponse> OnMultiplayerUploadCertificateResultEvent;
    }
}
#endif
